using Karpenko.University.Backend.Application.Pagination;
using Karpenko.University.Backend.Core.ResultPattern;
using Karpenko.University.Backend.Domain.Order;

namespace Karpenko.University.Backend.Application.UseCases.GetOrdersByOwnerId;

/// <summary>
/// Результаты сценария поиска заказов по идентификатору владельца
/// </summary>
public static class Results {
  /// <summary>
  /// Список заказов
  /// </summary>
  public sealed record OrderCollection(PaginatedItems<OrderModel> Orders) : IResult;
}
