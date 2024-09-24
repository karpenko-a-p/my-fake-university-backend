namespace Karpenko.University.Backend.Domain.Course;

/// <summary>
/// Комментарий к курсу
/// </summary>
public sealed class CourseComment {
  /// <summary>
  /// Идентификатор
  /// </summary>
  public ulong Id { get; set; }

  /// <summary>
  /// Идентификатор курса
  /// </summary>
  public ulong CourseId { get; set; }

  /// <summary>
  /// Идентификатор автора комментария
  /// </summary>
  public ulong AuthorId { get; set; }

  /// <summary>
  /// Содержание комментария
  /// </summary>
  public string Content { get; set; } = string.Empty;

  /// <summary>
  /// Оценка автора комментария курсу
  /// </summary>
  public CourseQuality Quality { get; set; } = CourseQuality.Good;
  
  /// <summary>
  /// Дата написания комментарий
  /// </summary>
  public DateTime CreationDate { get; set; }
}
