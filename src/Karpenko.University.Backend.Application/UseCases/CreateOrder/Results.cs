using Karpenko.University.Backend.Core.ResultPattern;
using Karpenko.University.Backend.Domain.Order;

namespace Karpenko.University.Backend.Application.UseCases.CreateOrder;

/// <summary>
/// Результаты сценария создания заказа
/// </summary>
public static class Results {
  /// <summary>
  /// Заказ создан
  /// </summary>
  public sealed record Created(OrderModel Order) : IResult;

  /// <summary>
  /// Уже куплено
  /// </summary>
  public sealed record AlreadyBought : IResult;
}
