namespace Karpenko.University.Backend.Domain.Course;

/// <summary>
/// Оценка пользователя качества курса
/// </summary>
public enum CourseQuality : byte {
  /// <summary>
  /// Пользователь доволен
  /// </summary>
  Good,
  
  /// <summary>
  /// Нейтрально
  /// </summary>
  Neutral,
  
  /// <summary>
  /// Плохо
  /// </summary>
  Bad
}
