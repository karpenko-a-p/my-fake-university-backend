using Karpenko.University.Backend.Domain.Order;

namespace Karpenko.University.Backend.Application.UseCases.GetOrderById;

/// <summary>
/// Репозиторий для работы с заказами
/// </summary>
public interface IOrderRepository {
  /// <summary>
  /// Получение заказа по идентификатору
  /// </summary>
  Task<OrderModel?> GetOrderByIdAsync(long orderId, CancellationToken cancellationToken);
}
