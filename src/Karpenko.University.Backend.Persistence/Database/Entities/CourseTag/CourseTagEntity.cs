using Karpenko.University.Backend.Persistence.Database.Entities.Course;
using Karpenko.University.Backend.Persistence.Database.Entities.CourseBindCourseTag;

namespace Karpenko.University.Backend.Persistence.Database.Entities.CourseTag;

/// <summary>
/// Сущность тэга курса
/// </summary>
internal sealed class CourseTagEntity {
  /// <summary>
  /// Идентификатор
  /// </summary>
  public long Id { get; set; }

  /// <summary>
  /// Название
  /// </summary>
  public string Name { get; set; } = string.Empty;
  
  /// <summary>
  /// Навигация на курсы
  /// </summary>
  public ICollection<CourseEntity> Courses { get; set; } = [];

  /// <summary>
  /// Навигация на соединение с курсами
  /// </summary>
  public ICollection<CourseBindCourseTagEntity> CoursesBindings { get; set; } = [];
}
