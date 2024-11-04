﻿using System.Net.Mime;
using Karpenko.University.Backend.API.Controllers.Order.Contracts;
using Karpenko.University.Backend.Domain.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GetStudentById = Karpenko.University.Backend.Application.UseCases.GetStudentById;
using GetCourseById = Karpenko.University.Backend.Application.UseCases.GetCourseById;
using CreateOrder = Karpenko.University.Backend.Application.UseCases.CreateOrder;
using AddAccess = Karpenko.University.Backend.Application.UseCases.AddAccess;
using GetOrderById = Karpenko.University.Backend.Application.UseCases.GetOrderById;
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
        Results.ValidationFailure { ValidationResult: var validationResult } => BadRequest(ErrorContract.ValidationError(validationResult)),
        _ => CantHandleRequest()
      };

    // Предоставление доступа на отмену заказа
    var addAccessResult = await addAccessUseCase
      .SetEntryData(new(student.Id, order.Id, PermissionType.Delete, PermissionSubject.Order))
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
    CancellationToken cancellationToken
  ) {
    // Получение заказа
    var getOrderResult = await getOrderByIdUseCase
      .SetEntryData(orderId)
      .ExecuteAsync(cancellationToken);
    
    if (getOrderResult is not GetOrderById.Results.Found { Order: var order })
      return getOrderResult switch {
        GetOrderById.Results.NotFound => NotFound(),
        _ => CantHandleRequest()
      };

    // Проверка доступа, надо бы через пермишены, но мне в падлу уже =)
    if (GetClaimId() != order.Payer.Id)
      return Forbidden(ErrorContract.Forbidden("Нет доступа для просмотра данных заказа"));
    
    return Ok(new OrderContract(order));
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
  public async Task<IActionResult> DeleteOrderAsync(
    [FromRoute(Name = "orderId")] long orderId,
    CancellationToken cancellationToken
  ) {
    return Ok();
  }
}
