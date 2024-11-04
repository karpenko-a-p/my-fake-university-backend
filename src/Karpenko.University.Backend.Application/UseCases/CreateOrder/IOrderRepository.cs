using Karpenko.University.Backend.Domain.Order;

namespace Karpenko.University.Backend.Application.UseCases.CreateOrder;

/// <summary>
/// Репозиторий для работы с данными заказов
/// </summary>
public interface IOrderRepository {
  /// <summary>
  /// Создание нового заказа
  /// </summary>
  Task<OrderModel> CreateOrderAsync(CreateOrderDto order, CancellationToken cancellationToken);
}
