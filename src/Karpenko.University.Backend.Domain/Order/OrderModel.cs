namespace Karpenko.University.Backend.Domain.Order;

/// <summary>
/// Модель заказа
/// </summary>
public sealed class OrderModel {
  /// <summary>
  /// Максимальная длинна комментария к заказу
  /// </summary>
  public const int DescriptionMaxLength = 512;

  /// <summary>
  /// Идентификатор
  /// </summary>
  public long Id { get; set; }

  /// <summary>
  /// Комментарий к платежу
  /// </summary>
  public string Description { get; set; } = string.Empty;

  /// <summary>
  /// Стоимость
  /// </summary>
  public decimal Price { get; set; }

  /// <summary>
  /// Покупаемый продукт
  /// </summary>
  public OrderProduct Product { get; set; } = new();

  /// <summary>
  /// Плательщик
  /// </summary>
  public OrderPayer Payer { get; set; } = new();

  /// <summary>
  /// Время оплаты
  /// </summary>
  public DateTime PaymentTime { get; set; }
}
