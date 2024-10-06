namespace Karpenko.University.Backend.Domain.Course;

/// <summary>
/// Интерфейс элемента курса (материала курса)
/// </summary>
public interface ICourseContentItem {
  /// <summary>
  /// Идентификатор
  /// </summary>
  long Id { get; set; }
  
  /// <summary>
  /// Идентификатор курса к которому относится материал
  /// </summary>
  long CourseId { get; set; }

  /// <summary>
  /// Порядок данного элемента в этапе курса
  /// </summary>
  ushort Position { get; set; }

  /// <summary>
  /// Тип материала
  /// </summary>
  CourseContentItemType Type { get; }
}
