namespace Karpenko.University.Backend.Domain.Course;

/// <summary>
/// Видео элемент курса 
/// </summary>
public sealed class CourseContentVideoItem : ICourseContentItem {
  /// <inheritdoc />
  public ulong Id { get; set; }

  /// <inheritdoc />
  public ulong CourseId { get; set; }

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
  public ulong VideoId { get; set; }

  /// <summary>
  /// Постер видео
  /// </summary>
  public string PosterUrl { get; set; } = string.Empty;
}
