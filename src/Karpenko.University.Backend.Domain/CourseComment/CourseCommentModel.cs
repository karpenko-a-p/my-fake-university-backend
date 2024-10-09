namespace Karpenko.University.Backend.Domain.CourseComment;

/// <summary>
/// Комментарий к курсу
/// </summary>
public sealed class CourseComment {
  /// <summary>
  /// Идентификатор
  /// </summary>
  public long Id { get; set; }

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
