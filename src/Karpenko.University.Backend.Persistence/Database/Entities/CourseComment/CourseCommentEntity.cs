﻿using Karpenko.University.Backend.Domain.CourseComment;
using Karpenko.University.Backend.Persistence.Database.Entities.Course;
using Karpenko.University.Backend.Persistence.Database.Entities.Student;

namespace Karpenko.University.Backend.Persistence.Database.Entities.CourseComment;

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
  /// Идентификатор курса
  /// </summary>
  public long? CourseId { get; set; }

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
  
  /// <summary>
  /// Навигация на курс
  /// </summary>
  public CourseEntity? Course { get; set; }
}