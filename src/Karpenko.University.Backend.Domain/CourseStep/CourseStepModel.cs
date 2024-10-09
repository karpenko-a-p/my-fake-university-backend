namespace Karpenko.University.Backend.Domain.CourseStep;

/// <summary>
/// Этап курса
/// </summary>
public sealed class CourseStepModel {
  /// <summary>
  /// Максимальная длинна названия этапа курса
  /// </summary>
  public const int NameMaxLength = 255;

  /// <summary>
  /// Идентификатор
  /// </summary>
  public long Id { get; set; }

  /// <summary>
  /// Индекс позиции шага в курсе
  /// </summary>
  public int PositionIndex { get; set; }

  /// <summary>
  /// Названия этапа курса
  /// </summary>
  public string Name { get; set; } = string.Empty;

  /// <summary>
  /// Описание
  /// </summary>
  public string Description { get; set; } = string.Empty;

  /// <summary>
  /// Примерное время прохождения (в минутах)
  /// </summary>
  public int PassageTime { get; set; }
}
