using Karpenko.University.Backend.Domain.Course;

namespace Karpenko.University.Backend.Domain.Course;

/// <summary>
/// Файл - элемент курса
/// </summary>
public sealed class CourseContentFileItem : ICourseContentItem {
  /// <inheritdoc />
  public ulong Id { get; set; }

  /// <inheritdoc />
  public ulong CourseId { get; set; }

  /// <inheritdoc />
  public ushort Position { get; set; }

  /// <inheritdoc />
  public CourseContentItemType Type => CourseContentItemType.File;

  /// <summary>
  /// Название секции
  /// </summary>
  public string Title { get; set; } = string.Empty;
  
  /// <summary>
  /// Описание файла
  /// </summary>
  public string Description { get; set; } = string.Empty;
  
  /// <summary>
  /// Идентификатор файла
  /// </summary>
  public ulong FileId { get; set; }
  
  /// <summary>
  /// Название файла
  /// </summary>
  public string FileName { get; set; } = string.Empty;
  
  /// <summary>
  /// Тип файла
  /// </summary>
  public string FileType { get; set; } = string.Empty;
}
