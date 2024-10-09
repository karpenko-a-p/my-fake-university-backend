namespace Karpenko.University.Backend.Domain.CourseComment;

/// <summary>
/// Оценка пользователя качества курса
/// </summary>
public enum CourseQuality : byte {
  /// <summary>
  /// Пользователь доволен
  /// </summary>
  Good = 1,
  
  /// <summary>
  /// Нейтрально
  /// </summary>
  Neutral,
  
  /// <summary>
  /// Плохо
  /// </summary>
  Bad
}
