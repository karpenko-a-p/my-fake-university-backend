using Karpenko.University.Backend.Core.ResultPattern;

namespace Karpenko.University.Backend.Application.UseCases.DeleteOrderById;

/// <summary>
/// Сценарий удаления/отмены заказа
/// </summary>
public sealed class UseCase(IOrderRepository orderRepository) : AbstractAsyncUseCase<long> {
  /// <inheritdoc />
  public override async Task<IResult> ExecuteAsync(CancellationToken cancellationToken) {
    var order = await orderRepository.GetOrderByIdAsync(EntryData, cancellationToken);

    if (order is null)
      return new Results.NotFound();
    
    await orderRepository.DeleteOrderByIdAsync(EntryData, cancellationToken);

    return new Results.Deleted(order);
  }
}
