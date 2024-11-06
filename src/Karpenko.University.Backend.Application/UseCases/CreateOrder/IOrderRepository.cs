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

  /// <summary>
  /// Проверка, что уже существует подобный заказ и он оплачен
  /// </summary>
  Task<bool> CheckIfAlreadyBoughtAsync(long payerId, long productId, CancellationToken cancellationToken);
}
