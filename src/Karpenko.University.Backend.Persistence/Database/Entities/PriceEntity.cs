namespace Karpenko.University.Backend.Persistence.Database.Entities;

/// <summary>
/// Сущность стоимости товара
/// </summary>
internal sealed class PriceEntity {
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
  
  /// <summary>
  /// Навигация на курс (если привязка к курсу)
  /// </summary>
  public CourseEntity? Course { get; set; }
}
