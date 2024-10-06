namespace Karpenko.University.Backend.Domain.Course;

/// <summary>
/// Видео элемент курса 
/// </summary>
public sealed class CourseContentVideoItem : ICourseContentItem {
  /// <inheritdoc />
  public long Id { get; set; }

  /// <inheritdoc />
  public long CourseId { get; set; }

  /// <inheritdoc />
  public ushort Position { get; set; }

  /// <inheritdoc />
  public CourseContentItemType Type => CourseContentItemType.Video;

  /// <summary>
  /// Название видео
  /// </summary>
  public string Name { get; set; } = string.Empty;

  /// <summary>
  /// Идентификатор видео
  /// </summary>
  public long VideoId { get; set; }

  /// <summary>
  /// Постер видео
  /// </summary>
  public string PosterUrl { get; set; } = string.Empty;
}
