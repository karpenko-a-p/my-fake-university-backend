﻿using Karpenko.University.Backend.Application.Pagination;
using Karpenko.University.Backend.Domain.Order;
using Karpenko.University.Backend.Domain.Permission;
using Karpenko.University.Backend.Persistence.Database.Contexts;
using Karpenko.University.Backend.Persistence.Database.Entities.Order;
using Microsoft.EntityFrameworkCore;
using CreateOrder = Karpenko.University.Backend.Application.UseCases.CreateOrder;
using GetOrderById = Karpenko.University.Backend.Application.UseCases.GetOrderById;
using DeleteOrderById = Karpenko.University.Backend.Application.UseCases.DeleteOrderById;
using PayOrderById = Karpenko.University.Backend.Application.UseCases.PayOrderById;
using GetOrdersByOwnerId = Karpenko.University.Backend.Application.UseCases.GetOrdersByOwnerId;

namespace Karpenko.University.Backend.Persistence.Repositories;

/// <summary>
/// Репозиторий для работы с данными заказов
/// </summary>
internal sealed class OrderRepository(PostgresDbContext db) : AbstractRepository<PostgresDbContext>(db),
  CreateOrder.IOrderRepository,
  GetOrderById.IOrderRepository,
  DeleteOrderById.IOrderRepository,
  PayOrderById.IOrderRepository,
  GetOrdersByOwnerId.IOrderRepository
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
      PaymentStatus = PaymentStatus.Unpaid
    };
    
    await db.Orders.AddAsync(orderEntity, cancellationToken);
    await db.SaveChangesAsync(cancellationToken);

    return orderEntity.ToOrderModel();
  }

  /// <inheritdoc />
  public Task<bool> CheckIfAlreadyBoughtAsync(long payerId, long productId, CancellationToken cancellationToken) {
    return db.Orders.AnyAsync(order => order.PayerId == payerId &&
                                       order.ProductId == productId &&
                                       order.PaymentStatus == PaymentStatus.Paid, cancellationToken);
  }

  /// <inheritdoc />
  public async Task<OrderModel?> GetOrderByIdAsync(long orderId, CancellationToken cancellationToken) {
    var orderEntity = await db.Orders
      .AsNoTracking()
      .FirstOrDefaultAsync(order => order.Id == orderId, cancellationToken);
    
    return orderEntity?.ToOrderModel();
  }

  /// <inheritdoc />
  public async Task DeleteOrderByIdAsync(long id, CancellationToken cancellationToken) {
    await InTransactionAsync(async () => {
      await db.Orders
        .Where(order => order.Id == id)
        .ExecuteDeleteAsync(cancellationToken);

      await db.Permissions
        .Where(permission => permission.SubjectId == id &&
                             permission.PermissionSubject == PermissionSubject.Order)
        .ExecuteDeleteAsync(cancellationToken);
    }, cancellationToken);
  }

  /// <inheritdoc />
  public async Task PayOrderByIdAsync(long orderId, CancellationToken cancellationToken) {
    await db.Orders
      .Where(order => order.Id == orderId)
      .ExecuteUpdateAsync(
        builder => builder.SetProperty(order => order.PaymentStatus, PaymentStatus.Paid),
        cancellationToken);
  }

  /// <inheritdoc />
  public async Task<ICollection<OrderModel>> GetOrdersByOwnerId(long ownerId, PaginationModel pagination, CancellationToken cancellationToken) {
    return await db.Orders
      .AsNoTracking()
      .Where(order => order.PayerId == ownerId)
      .Paginate(pagination)
      .Select(order => order.ToOrderModel())
      .ToListAsync(cancellationToken);
  }

  /// <inheritdoc />
  public Task<int> GetTotalOrdersByOwnerId(long ownerId, CancellationToken cancellationToken) {
    return db.Orders.CountAsync(order => order.PayerId == ownerId, cancellationToken);
  }
}
