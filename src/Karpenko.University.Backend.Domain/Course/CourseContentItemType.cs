namespace Karpenko.University.Backend.Domain.Course;

/// <summary>
/// Тип материала (Формат)
/// </summary>
public enum CourseContentItemType : byte {
  /// <summary>
  /// Текст
  /// </summary>
  Text,
  
  /// <summary>
  /// File
  /// </summary>
  File,
  
  /// <summary>
  /// Видео
  /// </summary>
  Video
}
