using Karpenko.University.Backend.Domain.CourseContent;
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
  /// Название файла с видео с контентом курса
  /// </summary>
  public string VideoFileName { get; set; } = string.Empty;
  
  /// <summary>
  /// Навигация на курс
  /// </summary>
  public CourseEntity? Course { get; set; }

  /// <summary>
  /// Преобразование к модели
  /// </summary>
  public CourseContentModel ToCourseContentModel() {
    return new() {
      Id = Id,
      VideoFileName = VideoFileName,
    };
  }
}
