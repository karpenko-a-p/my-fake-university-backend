using Karpenko.University.Backend.Core.ResultPattern;
using Karpenko.University.Backend.Domain.Order;

namespace Karpenko.University.Backend.Application.UseCases.GetOrderById;

/// <summary>
/// Результаты поиска заказа
/// </summary>
public static class Results {
  /// <summary>
  /// Заказ найден
  /// </summary>
  public sealed record Found(OrderModel Order) : IResult;

  /// <summary>
  /// Заказ не найден
  /// </summary>
  public sealed record NotFound : IResult;
}
