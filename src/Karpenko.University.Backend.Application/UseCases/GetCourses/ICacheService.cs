using Karpenko.University.Backend.Application.Pagination;
using Karpenko.University.Backend.Domain.Course;

namespace Karpenko.University.Backend.Application.UseCases.GetCourses;

/// <summary>
/// Сервис для работы с кэшем
/// </summary>
public interface ICacheService {
  /// <summary>
  /// Получение списка курсов из кэша
  /// </summary>
  Task<PaginatedItems<CourseModel>?> GetFromCacheAsync(PaginationModel pagination, CancellationToken cancellationToken);

  /// <summary>
  /// Сохранение списка курсов в кэше
  /// </summary>
  Task SetToCacheAsync(PaginatedItems<CourseModel> courses, CancellationToken cancellationToken);
}
