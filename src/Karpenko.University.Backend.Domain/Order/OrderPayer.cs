namespace Karpenko.University.Backend.Domain.Order;

/// <summary>
/// Данные плательщика заказа
/// </summary>
public sealed class OrderPayer {
  /// <summary>
  /// Максимальная длинна имени
  /// </summary>
  public const int NameMaxLength = 255;

  /// <summary>
  /// Максимальная длинна почты
  /// </summary>
  public const int EmailMaxLength = 128;

  /// <summary>
  /// Идентификатор
  /// </summary>
  public long Id { get; set; }

  /// <summary>
  /// Имя
  /// </summary>
  public string Name { get; set; } = string.Empty;

  /// <summary>
  /// Почта
  /// </summary>
  public string Email { get; set; } = string.Empty;
}
