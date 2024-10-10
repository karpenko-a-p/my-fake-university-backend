namespace Karpenko.University.Backend.Domain.Price;

/// <summary>
/// Модель стоимости курса
/// </summary>
public sealed class PriceModel {
  /// <summary>
  /// Идентификатор
  /// </summary>
  public long Id { get; set; }

  /// <summary>
  /// Цена товара
  /// </summary>
  public decimal Price { get; set; }

  /// <summary>
  /// Цена со скидкой
  /// </summary>
  public decimal SalePrice { get; set; }

  /// <summary>
  /// Процент скидки
  /// </summary>
  public float DiscountPercent { get; set; }

  /// <summary>
  /// Дата окончания действия скидки
  /// </summary>
  public DateTime SalesUntil { get; set; }
}
