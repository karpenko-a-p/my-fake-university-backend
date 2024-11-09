using Karpenko.University.Backend.Application.Pagination;
using Karpenko.University.Backend.Core.ResultPattern;

namespace Karpenko.University.Backend.Application.UseCases.GetOrdersByOwnerId;

/// <summary>
/// Сценарий посика заказов по идентификатору владельца/заказчика
/// </summary>
public sealed class UseCase(IOrderRepository orderRepository) : AbstractAsyncUseCase<EntryData> {
  /// <inheritgoc />
  public override async Task<IResult> ExecuteAsync(CancellationToken cancellationToken) {
    var orders = await orderRepository.GetOrdersByOwnerId(
      EntryData.OwnerId,
      EntryData.Pagination,
      cancellationToken);
    
    var ordersTotalCount = await orderRepository.GetTotalOrdersByOwnerId(
      EntryData.OwnerId,
      cancellationToken);

    var paginatedOrders = orders.ToPaginatedCollection(EntryData.Pagination, ordersTotalCount);

    return new Results.OrderCollection(paginatedOrders);
  }
}
