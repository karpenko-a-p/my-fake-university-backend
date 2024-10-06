namespace Karpenko.University.Backend.Domain.Course;

/// <summary>
/// Модель курса
/// </summary>
public sealed class CourseModel {
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
  /// Цена
  /// </summary>
  public CoursePriceModel Price { get; set; } = new();
  
  /// <summary>
  /// Дата создания
  /// </summary>
  public DateTime CreationDate { get; set; }
  
  /// <summary>
  /// Тэги
  /// </summary>
  public ICollection<CourseTagModel> Tags { get; set; } = [];
  
  /// <summary>
  /// Примерное время прохождения
  /// </summary>
  public uint PassageTime { get; set; }

  /// <summary>
  /// Этапы (Краткое описание)
  /// </summary>
  public ICollection<CourseStepInfoModel> CourseSteps { get; set; } = [];
  
  /// <summary>
  /// Кол-во людей купивших курс
  /// </summary>
  public uint Bought { get; set; }
}
