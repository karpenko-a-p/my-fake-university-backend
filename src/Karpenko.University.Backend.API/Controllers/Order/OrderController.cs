using System.Net.Mime;
using Karpenko.University.Backend.API.Controllers.Order.Contracts;
using Karpenko.University.Backend.Application.Pagination;
using Karpenko.University.Backend.Domain.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GetStudentById = Karpenko.University.Backend.Application.UseCases.GetStudentById;
using GetCourseById = Karpenko.University.Backend.Application.UseCases.GetCourseById;
using CreateOrder = Karpenko.University.Backend.Application.UseCases.CreateOrder;
using AddAccess = Karpenko.University.Backend.Application.UseCases.AddAccess;
using GetOrderById = Karpenko.University.Backend.Application.UseCases.GetOrderById;
using DeleteOrderById = Karpenko.University.Backend.Application.UseCases.DeleteOrderById;
using PayOrderById = Karpenko.University.Backend.Application.UseCases.PayOrderById;
using GetOrdersByOwnerId = Karpenko.University.Backend.Application.UseCases.GetOrdersByOwnerId;
using CheckAccess = Karpenko.University.Backend.Application.UseCases.CheckAccess;
using static Karpenko.University.Backend.Application.UseCases.CreateOrder.Constants;
using Results = Karpenko.University.Backend.Application.Validation.Results;

namespace Karpenko.University.Backend.API.Controllers.Order;

/// <summary>
/// Контроллер для работы заказами
/// </summary>
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
[Tags("api/order/v1")]
[Route("api/order/v1")]
public sealed class OrderController : ExtendedControllerBase {
  /// <summary>
  /// Создание заказа
  /// </summary>
  /// <response code="200">Заказ создан</response>
  /// <response code="400">Невозможно создать заказ</response>
  /// <response code="401">Необходима авторизация</response>
  [ProducesResponseType<OrderContract>(StatusCodes.Status200OK)]
  [ProducesResponseType<ErrorContract>(StatusCodes.Status400BadRequest)]
  [ProducesResponseType<ErrorContract>(StatusCodes.Status401Unauthorized)]
  [Authorize]
  [HttpPost]
  public async Task<IActionResult> CreateOrderAsync(
    [FromBody] CreateOrderContract createOrderContract,
    [FromServices] GetStudentById.UseCase getStudentByIdUseCase,
    [FromServices] GetCourseById.UseCase getCourseByIdUseCase,
    [FromServices] CreateOrder.UseCase createOrderUseCase,
    [FromServices] AddAccess.UseCase addAccessUseCase,
    CancellationToken cancellationToken
  ) {
    // Получение данных студента
    var studentId = GetClaimId();

    var getStudentResult = await getStudentByIdUseCase
      .SetEntryData(new(studentId))
      .ExecuteAsync(cancellationToken);

    if (getStudentResult is not GetStudentById.Results.Found { Student: var student })
      return BadRequest(ErrorContract.BadRequest($"Невозможно создать заказ для студента с идентификатором {studentId}"));

    // Получение данных курса
    var getCourseResult = await getCourseByIdUseCase
      .SetEntryData(new(createOrderContract.CourseId))
      .ExecuteAsync(cancellationToken);

    if (getCourseResult is not GetCourseById.Results.Found { Course: var course })
      return BadRequest(ErrorContract.BadRequest($"Невозможно создать заказ с курсом с идентификатором {createOrderContract.CourseId}"));

    // Создание заказа
    var createOrderResult = await createOrderUseCase
      .SetEntryData(new(student, course, createOrderContract.Description))
      .ExecuteAsync(cancellationToken);

    if (createOrderResult is not CreateOrder.Results.Created { Order: var order })
      return createOrderResult switch {
        Results.ValidationFailure { ValidationResult: var validationResult } => BadRequest(
          ErrorContract.ValidationError(validationResult)),
        CreateOrder.Results.AlreadyBought => BadRequest(ErrorContract.BadRequest("Нельзя сделать заказ повторно")),
        _ => CantHandleRequest()
      };

    // Предоставление доступа на отмену заказа
    var addAccessResult = await addAccessUseCase
      .SetEntryData(new ([
        new(student.Id, order.Id, PermissionType.Delete, PermissionSubject.Order),
        new(student.Id, order.Id, PermissionType.Update, PermissionSubject.Order),
        new(student.Id, order.Id, PermissionType.Read, PermissionSubject.Order),
        new(student.Id, AllOwnOrdersId, PermissionType.Read, PermissionSubject.Order),
      ]))
      .ExecuteAsync(cancellationToken);

    return addAccessResult switch {
      AddAccess.Results.Success => Ok(new OrderContract(order)),
      Results.ValidationFailure { ValidationResult: var validationResult } => BadRequest(ErrorContract.ValidationError(validationResult)),
      _ => CantHandleRequest()
    };
  }

  /// <summary>
  /// Оплата заказа
  /// </summary>
  /// <response code="200">Заказ оплачен</response>
  /// <response code="404">Заказ не найден</response>
  /// <response code="404">Оплачиваемый курс не найден</response>
  /// <response code="403">Недостаточно прав</response>
  /// <response code="401">Необходима авторизация</response>
  [ProducesResponseType<OrderContract>(StatusCodes.Status200OK)]
  [ProducesResponseType<ErrorContract>(StatusCodes.Status404NotFound)]
  [ProducesResponseType<ErrorContract>(StatusCodes.Status403Forbidden)]
  [ProducesResponseType<ErrorContract>(StatusCodes.Status401Unauthorized)]
  [Authorize]
  [HttpPost("{orderId:long:min(0)}")]
  public async Task<IActionResult> PayOrderAsync(
    [FromRoute(Name = "orderId")] long orderId,
    [FromServices] PayOrderById.UseCase payOrderByIdUseCase,
    [FromServices] CheckAccess.UseCase checkAccessUseCase,
    [FromServices] AddAccess.UseCase addAccessUseCase,
    CancellationToken cancellationToken
  ) {
    var checkAccessResult = await checkAccessUseCase
      .SetEntryData(new(GetClaimId(), orderId, PermissionType.Update, PermissionSubject.Order))
      .ExecuteAsync(cancellationToken);

    if (checkAccessResult is not CheckAccess.Results.HasAccess)
      return Forbidden(ErrorContract.Forbidden("Нет доступа для оплаты заказа"));

    // оплата заказа
    var payResult = await payOrderByIdUseCase
      .SetEntryData(orderId)
      .ExecuteAsync(cancellationToken);

    if (payResult is not PayOrderById.Results.Payed { Order: var order })
      return payResult switch {
        PayOrderById.Results.OrderNotFound => NotFound(ErrorContract.NotFound("Заказ не найден")),
        PayOrderById.Results.CourseNotFound => NotFound(ErrorContract.NotFound("Курс из заказа не найден")),
        PayOrderById.Results.PriceChanged => NotFound(ErrorContract.BadRequest("Цена за курс изменилась с момента формирования заказа")),
        _ => CantHandleRequest()
      };

    // Предоставление доступа к содержимому курса
    var addAccessResult = await addAccessUseCase
      .SetEntryData(new([
        new(order.Payer.Id, order.Product.Id, PermissionType.Read, PermissionSubject.CourseContent)
      ]))
      .ExecuteAsync(cancellationToken);

    return addAccessResult switch {
      AddAccess.Results.Success => Ok(new OrderContract(order)),
      _ => CantHandleRequest()
    };
  }

  /// <summary>
  /// Получение заказа по идентификатору
  /// </summary>
  /// <response code="200">Заказ найден</response>
  /// <response code="404">Заказ не найден</response>
  /// <response code="403">Недостаточно прав</response>
  /// <response code="401">Необходима авторизация</response>
  [ProducesResponseType<OrderContract>(StatusCodes.Status200OK)]
  [ProducesResponseType<ErrorContract>(StatusCodes.Status404NotFound)]
  [ProducesResponseType<ErrorContract>(StatusCodes.Status403Forbidden)]
  [ProducesResponseType<ErrorContract>(StatusCodes.Status401Unauthorized)]
  [Authorize]
  [HttpGet("{orderId:long:min(0)}")]
  public async Task<IActionResult> GetOrderByIdAsync(
    [FromRoute(Name = "orderId")] long orderId,
    [FromServices] GetOrderById.UseCase getOrderByIdUseCase,
    [FromServices] CheckAccess.UseCase checkAccessUseCase,
    CancellationToken cancellationToken
  ) {
    // Проверка доступа
    var checkAccessResult = await checkAccessUseCase
      .SetEntryData(new(GetClaimId(), orderId, PermissionType.Read, PermissionSubject.Order))
      .ExecuteAsync(cancellationToken);

    if (checkAccessResult is not CheckAccess.Results.HasAccess)
      return Forbidden(ErrorContract.Forbidden("Нет доступа для просмотра данных заказа"));

    // Получение заказа
    var getOrderResult = await getOrderByIdUseCase
      .SetEntryData(orderId)
      .ExecuteAsync(cancellationToken);

    if (getOrderResult is not GetOrderById.Results.Found { Order: var order })
      return getOrderResult switch {
        GetOrderById.Results.NotFound => NotFound(),
        _ => CantHandleRequest()
      };

    return Ok(new OrderContract(order));
  }

  /// <summary>
  /// Получение заказов определенного пользователя
  /// </summary>
  /// <response code="200">Список заказов</response>
  /// <response code="401">Необходима авторизация</response>
  /// <response code="403">Недостаточно прав</response>
  [ProducesResponseType<PaginatedItems<OrderContract>>(StatusCodes.Status200OK)]
  [ProducesResponseType<ErrorContract>(StatusCodes.Status401Unauthorized)]
  [ProducesResponseType<ErrorContract>(StatusCodes.Status403Forbidden)]
  [Authorize]
  [HttpGet("by-owner/{studentId:long:min(0)}")]
  public async Task<IActionResult> GetOrderByStudentIdAsync(
    [FromRoute(Name = "studentId")] long studentId,
    [FromQuery] PaginationModel paginationModel,
    [FromServices] GetOrdersByOwnerId.UseCase getOrdersByOwnerIdUseCase,
    [FromServices] CheckAccess.UseCase checkAccessUseCase,
    CancellationToken cancellationToken
  ) {
    // Проверка доступа
    var checkAccessResult = await checkAccessUseCase
      .SetEntryData(new(GetClaimId(), AllOwnOrdersId, PermissionType.Read, PermissionSubject.Order))
      .ExecuteAsync(cancellationToken);

    if (checkAccessResult is not CheckAccess.Results.HasAccess)
      return Forbidden(ErrorContract.Forbidden("Нет доступа для просмотра заказов"));

    // Получение заказов
    var getResult = await getOrdersByOwnerIdUseCase
      .SetEntryData(new(studentId, paginationModel))
      .ExecuteAsync(cancellationToken);

    if (getResult is not GetOrdersByOwnerId.Results.OrderCollection { Orders: var orders })
      return CantHandleRequest();

    return Ok(orders.Map(order => new OrderContract(order)));
  }

  /// <summary>
  /// Отмена и удаление заказа
  /// </summary>
  ///<response code="200">Заказ удален</response>
  /// <response code="404">Заказ не найден</response>
  /// <response code="403">Недостаточно прав</response>
  /// <response code="401">Необходима авторизация</response>
  [ProducesResponseType<OrderContract>(StatusCodes.Status200OK)]
  [ProducesResponseType<ErrorContract>(StatusCodes.Status404NotFound)]
  [ProducesResponseType<ErrorContract>(StatusCodes.Status403Forbidden)]
  [ProducesResponseType<ErrorContract>(StatusCodes.Status401Unauthorized)]
  [Authorize]
  [HttpDelete("{orderId:long:min(0)}")]
  public async Task<IActionResult> DeleteOrderByIdAsync(
    [FromRoute(Name = "orderId")] long orderId,
    [FromServices] DeleteOrderById.UseCase deleteOrderByIdUseCase,
    [FromServices] GetOrderById.UseCase getOrderByIdUseCase,
    [FromServices] CheckAccess.UseCase checkAccessUseCase,
    CancellationToken cancellationToken
  ) {
    // Проверка доступа
    var checkAccessResult = await checkAccessUseCase
      .SetEntryData(new(GetClaimId(), orderId, PermissionType.Delete, PermissionSubject.Order))
      .ExecuteAsync(cancellationToken);

    if (checkAccessResult is not CheckAccess.Results.HasAccess)
      return Forbidden(ErrorContract.Forbidden("Нет доступа для удаление заказа"));

    // получение данных заказа
    var getOrderResult = await getOrderByIdUseCase
      .SetEntryData(orderId)
      .ExecuteAsync(cancellationToken);

    if (getOrderResult is not GetOrderById.Results.Found)
      return NotFound(ErrorContract.NotFound("Заказ не найден"));

    // Удаление заказа
    var deleteResult = await deleteOrderByIdUseCase
      .SetEntryData(orderId)
      .ExecuteAsync(cancellationToken);

    return deleteResult switch {
      DeleteOrderById.Results.NotFound => NotFound(ErrorContract.NotFound("Заказ не найден")),
      DeleteOrderById.Results.Deleted { Order: var order } => Ok(new OrderContract(order)),
      _ => CantHandleRequest()
    };
  }
}
