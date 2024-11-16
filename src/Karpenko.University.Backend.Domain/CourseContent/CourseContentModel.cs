namespace Karpenko.University.Backend.Domain.CourseContent;

/// <summary>
/// Модель содержания курса
/// </summary>
public sealed class CourseContentModel {
  /// <summary>
  /// Идентификатор
  /// </summary>
  public long Id { get; set; }

  /// <summary>
  /// Название файла с видео с контентом курса
  /// </summary>
  public string VideoFileName { get; set; } = string.Empty;
}
