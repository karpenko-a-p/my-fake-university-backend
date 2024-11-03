using System.Net.Mime;
using Karpenko.University.Backend.API.Controllers.Order.Contracts;
using Microsoft.AspNetCore.Mvc;

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
  [HttpPost]
  public async Task<IActionResult> CreateOrderAsync(
    [FromBody] CreateOrderContract createOrderContract,
    CancellationToken cancellationToken
  ) {
    return Ok();
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
