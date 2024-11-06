using Karpenko.University.Backend.Domain.Order;

namespace Karpenko.University.Backend.Application.UseCases.DeleteOrderById;

/// <summary>
/// Репозиторий для работы с заказами
/// </summary>
public interface IOrderRepository {
  /// <summary>
  /// Удаление заказа по идентификатору
  /// </summary>
  Task DeleteOrderByIdAsync(long id, CancellationToken cancellationToken);

  /// <summary>
  /// Поиск заказа по идентификатору
  /// </summary>
  Task<OrderModel?> GetOrderByIdAsync(long orderId, CancellationToken cancellationToken);
}
