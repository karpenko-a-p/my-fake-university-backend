namespace Karpenko.University.Backend.Persistence.Database.Entities;

/// <summary>
/// Таблица со связями курсов и тэгов к курсам в БД (Многие ко многим между курсами и тэгами к ним)
/// </summary>
internal sealed class CourseBindCourseTagEntity {
  /// <summary>
  /// Идентификатор курса
  /// </summary>
  public long CourseId { get; set; }
  
  /// <summary>
  /// Идентификатор тэга
  /// </summary>
  public long CourseTagId { get; set; }

  /// <summary>
  /// Навигация на тэг
  /// </summary>
  public CourseTagEntity? Tag { get; set; }
  
  /// <summary>
  /// Навигация на курс
  /// </summary>
  public CourseEntity? Course { get; set; }
}
