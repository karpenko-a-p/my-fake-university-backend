using Karpenko.University.Backend.Core.ResultPattern;

namespace Karpenko.University.Backend.Application.UseCases.GetOrderById;

/// <summary>
/// Сценарий поиска заказа по идентификатору
/// </summary>
public sealed class UseCase(IOrderRepository orderRepository) : AbstractAsyncUseCase<long> {
  /// <inheritdoc />
  public override async Task<IResult> ExecuteAsync(CancellationToken cancellationToken) {
    var order = await orderRepository.GetOrderByIdAsync(EntryData, cancellationToken);

    return order is null
      ? new Results.NotFound()
      : new Results.Found(order);
  }
}
