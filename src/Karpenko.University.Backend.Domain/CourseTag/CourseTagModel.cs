namespace Karpenko.University.Backend.Domain.CourseTag;

/// <summary>
/// Модель тэга курса
/// </summary>
public sealed class CourseTagModel {
  /// <summary>
  /// Максимальная длинна названия тэга
  /// </summary>
  public const int NameMaxLength = 128;

  /// <summary>
  /// Идентификатор
  /// </summary>
  public long Id { get; set; }

  /// <summary>
  /// Название
  /// </summary>
  public string Name { get; set; } = string.Empty;
}
