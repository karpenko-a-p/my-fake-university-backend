using Karpenko.University.Backend.Core.ResultPattern;
using Karpenko.University.Backend.Domain.Order;

namespace Karpenko.University.Backend.Application.UseCases.PayOrderById;

/// <summary>
/// Сценарий оплаты заказа
/// </summary>
public sealed class UseCase(IOrderRepository orderRepository, ICourseRepository courseRepository) : AbstractAsyncUseCase<long> {
  /// <inheritdoc />
  public override async Task<IResult> ExecuteAsync(CancellationToken cancellationToken) {
    var course = await courseRepository.GetCourseByOrderId(EntryData, cancellationToken);
    
    if (course is null)
      return new Results.CourseNotFound();
    
    var order = await orderRepository.GetOrderByIdAsync(EntryData, cancellationToken);
    
    if (order is null)
      return new Results.OrderNotFound();

    if (order.Price != course.Price)
      return new Results.PriceChanged();
    
    // Тут могла бы быть оплата, но ее не будет =)
    
    await orderRepository.PayOrderByIdAsync(EntryData, cancellationToken);

    order.PaymentStatus = PaymentStatus.Paid;

    return new Results.Payed(order);
  }
}
