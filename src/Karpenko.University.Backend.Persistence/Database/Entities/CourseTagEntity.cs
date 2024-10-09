﻿namespace Karpenko.University.Backend.Persistence.Database.Entities;

/// <summary>
/// Сущность тэга курса
/// </summary>
internal sealed class CourseTagEntity {
  /// <summary>
  /// Идентификатор
  /// </summary>
  public long Id { get; set; }

  /// <summary>
  /// Название
  /// </summary>
  public string Name { get; set; } = string.Empty;
}