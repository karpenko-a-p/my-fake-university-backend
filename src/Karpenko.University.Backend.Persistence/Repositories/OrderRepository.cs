using Karpenko.University.Backend.Domain.Order;
using Karpenko.University.Backend.Persistence.Database.Contexts;
using Karpenko.University.Backend.Persistence.Database.Entities.Order;
using Microsoft.EntityFrameworkCore;
using CreateOrder = Karpenko.University.Backend.Application.UseCases.CreateOrder;
using GetOrderById = Karpenko.University.Backend.Application.UseCases.GetOrderById;

namespace Karpenko.University.Backend.Persistence.Repositories;

/// <summary>
/// Репозиторий для работы с данными заказов
/// </summary>
internal sealed class OrderRepository(PostgresDbContext db) : AbstractRepository<PostgresDbContext>(db),
  CreateOrder.IOrderRepository,
  GetOrderById.IOrderRepository
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

  /// <inheritdoc />
  public async Task<OrderModel?> GetOrderByIdAsync(long orderId, CancellationToken cancellationToken) {
    var orderEntity = await db.Orders
      .AsNoTracking()
      .FirstOrDefaultAsync(order => order.Id == orderId, cancellationToken);
    
    return orderEntity?.ToOrderModel();
  }
}
