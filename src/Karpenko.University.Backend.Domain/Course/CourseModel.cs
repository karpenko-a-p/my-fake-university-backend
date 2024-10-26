namespace Karpenko.University.Backend.Domain.Course;

/// <summary>
/// Модель курса
/// </summary>
public sealed class CourseModel {
  /// <summary>
  /// Максимальная длинна названия
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

  /// <summary>
  /// Описание
  /// </summary>
  public string Description { get; set; } = string.Empty;

  /// <summary>
  /// Лого курса
  /// </summary>
  public string LogoUrl { get; set; } = string.Empty;
  
  /// <summary>
  /// Дата создания
  /// </summary>
  public DateTime CreationDate { get; set; }
  
  /// <summary>
  /// Кол-во людей купивших курс
  /// </summary>
  public long BoughtCount { get; set; }

  /// <summary>
  /// Цена товара
  /// </summary>
  public decimal Price { get; set; }
}
