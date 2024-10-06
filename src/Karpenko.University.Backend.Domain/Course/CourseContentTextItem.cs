namespace Karpenko.University.Backend.Domain.Course;

/// <summary>
/// Текстовый элемент курса
/// </summary>
public sealed class CourseContentTextItem : ICourseContentItem {
  /// <inheritdoc />
  public long Id { get; set; }

  /// <inheritdoc />
  public long CourseId { get; set; }

  /// <inheritdoc />
  public ushort Position { get; set; }

  /// <inheritdoc />
  public CourseContentItemType Type => CourseContentItemType.Text;

  /// <summary>
  /// Текстовое содержание
  /// </summary>
  public string Content { get; set; } = string.Empty;

  /// <summary>
  /// Название секции
  /// </summary>
  public string Title { get; set; } = string.Empty;
}
