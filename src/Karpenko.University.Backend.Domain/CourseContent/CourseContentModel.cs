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
  /// Путь к видео с контентом курса
  /// </summary>
  public string VideoPath { get; set; } = string.Empty;
}
