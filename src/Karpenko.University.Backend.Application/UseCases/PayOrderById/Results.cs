using Karpenko.University.Backend.Core.ResultPattern;
using Karpenko.University.Backend.Domain.Order;

namespace Karpenko.University.Backend.Application.UseCases.PayOrderById;

/// <summary>
/// Результаты для сценария оплаты
/// </summary>
public sealed class Results {
  /// <summary>
  /// Заказ оплачен
  /// </summary>
  public sealed record Payed(OrderModel Order) : IResult;

  /// <summary>
  /// Курс не найден
  /// </summary>
  public sealed record CourseNotFound : IResult;

  /// <summary>
  /// Заказ не найден
  /// </summary>
  public sealed record OrderNotFound : IResult;
  
  /// <summary>
  /// Цена изменилась
  /// </summary>
  public sealed record PriceChanged : IResult;
}
