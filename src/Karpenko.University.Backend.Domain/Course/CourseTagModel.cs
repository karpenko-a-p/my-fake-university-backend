namespace Karpenko.University.Backend.Domain.Course;

/// <summary>
/// Тэг курса
/// </summary>
public sealed class CourseTagModel {
  /// <summary>
  /// Идентификатор
  /// </summary>
  public ulong Id { get; set; }

  /// <summary>
  /// Название
  /// </summary>
  public string Name { get; set; } = string.Empty;
}
