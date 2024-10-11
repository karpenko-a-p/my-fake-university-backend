using Karpenko.University.Backend.Persistence.Database.Entities.Course;

namespace Karpenko.University.Backend.Persistence.Database.Entities.CourseStep;

/// <summary>
/// Сущность этапа курса в БД
/// </summary>
internal sealed class CourseStepEntity {
  /// <summary>
  /// Идентификатор
  /// </summary>
  public long Id { get; set; }
  
  /// <summary>
  /// Идентификатор курса
  /// </summary>
  public long CourseId { get; set; }

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
  
  /// <summary>
  /// Навигация на курс
  /// </summary>
  public CourseEntity? Course { get; set; }
}
