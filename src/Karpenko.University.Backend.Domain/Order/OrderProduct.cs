namespace Karpenko.University.Backend.Domain.Order;

/// <summary>
/// Данные покупаемого товара для заказа
/// </summary>
public sealed class OrderProduct {
  /// <summary>
  /// Максимальная длинна названия товара
  /// </summary>
  public const int NameMaxLength = 255;

  /// <summary>
  /// Идентификатор
  /// </summary>
  public long Id { get; set; }

  /// <summary>
  /// Название
  /// </summary>
  public string Name { get; set; } = string.Empty;
}
