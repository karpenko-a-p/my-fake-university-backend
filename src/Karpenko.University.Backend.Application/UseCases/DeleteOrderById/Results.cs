using Karpenko.University.Backend.Core.ResultPattern;
using Karpenko.University.Backend.Domain.Order;

namespace Karpenko.University.Backend.Application.UseCases.DeleteOrderById;

/// <summary>
/// Результаты сценария отмены/удаления заказа
/// </summary>
public static class Results {
  /// <summary>
  /// Заказ удален/отменен
  /// </summary>
  public sealed record Deleted(OrderModel Order) : IResult;
  
  /// <summary>
  /// Заказ не найден
  /// </summary>
  public sealed record NotFound : IResult;
}
