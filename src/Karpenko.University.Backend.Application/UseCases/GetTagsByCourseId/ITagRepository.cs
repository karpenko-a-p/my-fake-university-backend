using Karpenko.University.Backend.Domain.CourseTag;

namespace Karpenko.University.Backend.Application.UseCases.GetTagsByCourseId;

/// <summary>
/// Интерфейс для работы с курсами
/// </summary>
public interface ITagRepository {
  /// <summary>
  /// Получение тэгов по конкретному курсу
  /// </summary>
  Task<ICollection<CourseTagModel>> GetTagsByCourseIdAsync(long courseId, CancellationToken cancellationToken);
}
