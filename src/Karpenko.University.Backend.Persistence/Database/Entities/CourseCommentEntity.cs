using Karpenko.University.Backend.Domain.CourseComment;

namespace Karpenko.University.Backend.Persistence.Database.Entities;

/// <summary>
/// Сущность комментария к курсу в БД
/// </summary>
internal sealed class CourseCommentEntity {
  /// <summary>
  /// Идентификатор
  /// </summary>
  public long Id { get; set; }
  
  /// <summary>
  /// Идентификатор автора комментария
  /// </summary>
  public long? AuthorId { get; set; }

  /// <summary>
  /// Содержание комментария
  /// </summary>
  public string Content { get; set; } = string.Empty;

  /// <summary>
  /// Оценка автора комментария курсу
  /// </summary>
  public CourseQuality Quality { get; set; }
  
  /// <summary>
  /// Дата написания комментарий
  /// </summary>
  public DateTime CreationDate { get; set; }
  
  /// <summary>
  /// Навигация на втора
  /// </summary>
  public StudentEntity? Author { get; set; }
}
