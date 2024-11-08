using Karpenko.University.Backend.Domain.Order;

namespace Karpenko.University.Backend.Application.UseCases.PayOrderById;

/// <summary>
/// Репозиторий для работы с заказами
/// </summary>
public interface IOrderRepository {
  /// <summary>
  /// Записать в бд, что заказ оплачен
  /// </summary>
  Task PayOrderByIdAsync(long orderId, CancellationToken cancellationToken);
  
  /// <summary>
  /// Получение заказа по идентификатору
  /// </summary>
  Task<OrderModel?> GetOrderByIdAsync(long orderId, CancellationToken cancellationToken);
}
