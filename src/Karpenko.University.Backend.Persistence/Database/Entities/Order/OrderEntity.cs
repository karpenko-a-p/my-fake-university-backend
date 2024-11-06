using Karpenko.University.Backend.Domain.Order;

namespace Karpenko.University.Backend.Persistence.Database.Entities.Order;

/// <summary>
/// Сущность заказа в БД
/// </summary>
internal sealed class OrderEntity {
  /// <summary>
  /// Идентификатор
  /// </summary>
  public long Id { get; set; }
  
  /// <summary>
  /// Комментарий к платежу
  /// </summary>
  public string? Description { get; set; }

  /// <summary>
  /// Идентификатор плательщика
  /// </summary>
  public long PayerId { get; set; }
  
  /// <summary>
  /// Имя плательщика
  /// </summary>
  public string PayerName { get; set; } = string.Empty;
  
  /// <summary>
  /// Почта плательщика
  /// </summary>
  public string PayerEmail { get; set; } = string.Empty;
  
  /// <summary>
  /// Идентификатор продукта
  /// </summary>
  public long ProductId { get; set; }
  
  /// <summary>
  /// Название продукта
  /// </summary>
  public string ProductName { get; set; } = string.Empty;

  /// <summary>
  /// Стоимость
  /// </summary>
  public decimal Price { get; set; }

  /// <summary>
  /// Время создания заказа
  /// </summary>
  public DateTime CreateDate { get; set; }

  /// <summary>
  /// Статус оплаты
  /// </summary>
  public PaymentStatus PaymentStatus { get; set; }

  /// <summary>
  /// Преобразование сущности из бд к модели
  /// </summary>
  public OrderModel ToOrderModel() {
    return new() {
      Id = Id,
      Description = Description ?? string.Empty,
      CreateDate = CreateDate,
      Price = Price,
      PaymentStatus = PaymentStatus,
      Payer = new() {
        Id = PayerId,
        Email = PayerEmail,
        Name = PayerName
      },
      Product = new() {
        Id = ProductId,
        Name = ProductName,
      }
    };
  }
}
