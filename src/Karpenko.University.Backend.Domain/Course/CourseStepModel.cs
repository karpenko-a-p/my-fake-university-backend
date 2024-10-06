namespace Karpenko.University.Backend.Domain.Course;

/// <summary>
/// Этап курса
/// </summary>
public sealed class CourseStepModel {
  /// <summary>
  /// Идентификатор
  /// </summary>
  public long Id { get; set; }

  /// <summary>
  /// Названия этапа курса
  /// </summary>
  public string Name { get; set; } = string.Empty;
  
  /// <summary>
  /// Описание
  /// </summary>
  public string Description { get; set; } = string.Empty;

  /// <summary>
  /// Примерное время прохождения
  /// </summary>
  public uint PassageTime { get; set; }
  
  /// <summary>
  /// Лого шага
  /// </summary>
  public string LogoUrl { get; set; } = string.Empty;
  
  
}
