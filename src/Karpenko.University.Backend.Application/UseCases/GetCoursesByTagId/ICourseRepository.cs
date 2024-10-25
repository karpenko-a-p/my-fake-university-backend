using Karpenko.University.Backend.Application.Pagination;
using Karpenko.University.Backend.Domain.Course;

namespace Karpenko.University.Backend.Application.UseCases.GetCoursesByTagId;

/// <summary>
/// Репозиторий для работы с курсами
/// </summary>
public interface ICourseRepository {
  /// <summary>
  /// Получения пагинированного списка курсов с определенным тэгом
  /// </summary>
  Task<ICollection<CourseModel>> GetCoursesByTagIdAsync(long tagId, PaginationModel pagination, CancellationToken cancellationToken);

  /// <summary>
  /// Получение кол-ва курсов с определенным тэгом
  /// </summary>
  Task<int> GetCoursesCountByTagIdAsync(long tagId, PaginationModel pagination, CancellationToken cancellationToken);
}
