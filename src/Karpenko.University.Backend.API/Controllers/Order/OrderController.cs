using System.Net.Mime;
using Karpenko.University.Backend.API.Controllers.Order.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GetStudentById = Karpenko.University.Backend.Application.UseCases.GetStudentById;
using GetCourseById = Karpenko.University.Backend.Application.UseCases.GetCourseById;
using CreateOrder = Karpenko.University.Backend.Application.UseCases.CreateOrder;
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
    CancellationToken cancellationToken
  ) {
    var studentId = GetClaimId();

    var getStudentResult = await getStudentByIdUseCase
      .SetEntryData(new(studentId))
      .ExecuteAsync(cancellationToken);

    if (getStudentResult is not GetStudentById.Results.Found { Student: var student })
      return BadRequest(ErrorContract.BadRequest($"Невозможно создать заказ для студента с идентификатором {studentId}"));

    var getCourseResult = await getCourseByIdUseCase
      .SetEntryData(new(createOrderContract.CourseId))
      .ExecuteAsync(cancellationToken);

    if (getCourseResult is not GetCourseById.Results.Found { Course: var course })
      return BadRequest(ErrorContract.BadRequest($"Невозможно создать заказ с курсом с идентификатором {createOrderContract.CourseId}"));

    var createOrderResult = await createOrderUseCase
      .SetEntryData(new(student, course, createOrderContract.Description))
      .ExecuteAsync(cancellationToken);
    
    return createOrderResult switch {
      CreateOrder.Results.Created { Order: var order } => Ok(new OrderContract(order)),
      Results.ValidationFailure { ValidationResult: var validationResult } => BadRequest(ErrorContract.ValidationError(validationResult)),
      _ => CantHandleRequest()
    };
  }

  /// <summary>
  /// Оплата заказа
  /// </summary>
  [HttpPost("{orderId:long:min(0)}")]
  public async Task<IActionResult> PayOrderAsync(
    [FromRoute(Name = "orderId")] long orderId,
    CancellationToken cancellationToken
  ) {
    return Ok();
  }

  /// <summary>
  /// Получение заказа по идентификатору
  /// </summary>
  [HttpGet("{orderId:long:min(0)}")]
  public async Task<IActionResult> GetOrderByIdAsync(
    [FromRoute(Name = "orderId")] long orderId,
    CancellationToken cancellationToken
  ) {
    return Ok();
  }

  /// <summary>
  /// Получение заказов определенного пользователя
  /// </summary>
  [HttpGet("by-owner/{studentId:long:min(0)}")]
  public async Task<IActionResult> GetOrderByStudentIdAsync(
    [FromRoute(Name = "studentId")] long studentId,
    CancellationToken cancellationToken
  ) {
    return Ok();
  }

  /// <summary>
  /// Отмена и удаление заказа
  /// </summary>
  [HttpDelete("{orderId:long:min(0)}")]
  public async Task<IActionResult> DeleteOrderASync(
    [FromRoute(Name = "orderId")] long orderId,
    CancellationToken cancellationToken
  ) {
    return Ok();
  }
}
