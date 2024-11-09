using Karpenko.University.Backend.Application.Pagination;
using Karpenko.University.Backend.Domain.Order;

namespace Karpenko.University.Backend.Application.UseCases.GetOrdersByOwnerId;

/// <summary>
/// Репозиторий для работы с заказами
/// </summary>
public interface IOrderRepository {
  /// <summary>
  /// Получение паганированного списка заказов по идентификатору заказчика
  /// </summary>
  Task<ICollection<OrderModel>> GetOrdersByOwnerId(long ownerId, PaginationModel pagination, CancellationToken cancellationToken);
  
  /// <summary>
  /// Получение всего списка заказаов по идентификатору заказчика
  /// </summary>
  Task<int> GetTotalOrdersByOwnerId(long ownerId, CancellationToken cancellationToken);
}
