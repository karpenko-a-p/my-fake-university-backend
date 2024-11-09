using Karpenko.University.Backend.Persistence.Database.Entities.Course;

namespace Karpenko.University.Backend.Persistence.Database.Entities.CourseContent;

/// <summary>
/// Сущность содержимого курса
/// </summary>
internal sealed class CourseContentEntity {
  /// <summary>
  /// Идентификатор
  /// </summary>
  public long Id { get; set; }

  /// <summary>
  /// Идентификатор курса
  /// </summary>
  public long CourseId { get; set; }

  /// <summary>
  /// Путь к видео с контентом курса
  /// </summary>
  public string VideoPath { get; set; } = string.Empty;
  
  /// <summary>
  /// Навигация на курс
  /// </summary>
  public CourseEntity? Course { get; set; }
}
