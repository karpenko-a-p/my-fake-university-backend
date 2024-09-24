namespace Karpenko.University.Backend.Domain.Course;

/// <summary>
/// Цена курса
/// </summary>
public sealed class CoursePriceModel {
  /// <summary>
  /// Цена курса
  /// </summary>
  public decimal Price { get; set; }
  
  /// <summary>
  /// Цена со скидкой
  /// </summary>
  public decimal SalePrice { get; set; }
  
  /// <summary>
  /// Процент скидки
  /// </summary>
  public float Discount { get; set; }
  
  /// <summary>
  /// Дата окончания действия скидки
  /// </summary>
  public DateTime SalesUntil { get; set; }
}
