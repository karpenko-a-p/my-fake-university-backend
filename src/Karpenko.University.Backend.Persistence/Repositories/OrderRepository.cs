using Karpenko.University.Backend.Domain.Order;
using Karpenko.University.Backend.Persistence.Database.Contexts;
using Karpenko.University.Backend.Persistence.Database.Entities.Order;
using CreateOrder = Karpenko.University.Backend.Application.UseCases.CreateOrder;

namespace Karpenko.University.Backend.Persistence.Repositories;

/// <summary>
/// Репозиторий для работы с данными заказов
/// </summary>
internal sealed class OrderRepository(PostgresDbContext db) : AbstractRepository<PostgresDbContext>(db),
  CreateOrder.IOrderRepository
{
  /// <inheritdoc />
  public async Task<OrderModel> CreateOrderAsync(CreateOrder.CreateOrderDto order, CancellationToken cancellationToken) {
    var orderEntity = new OrderEntity {
      Price = order.Course.Price,
      Description = order.Description,
      PayerEmail = order.Student.Email,
      PayerId = order.Student.Id,
      PayerName = order.Student.Name,
      ProductId = order.Course.Id,
      ProductName = order.Course.Name,
    };
    
    await db.Orders.AddAsync(orderEntity, cancellationToken);
    await db.SaveChangesAsync(cancellationToken);

    return orderEntity.ToOrderModel();
  }
}
