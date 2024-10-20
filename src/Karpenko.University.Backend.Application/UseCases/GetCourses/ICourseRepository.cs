using Karpenko.University.Backend.Application.Pagination;
using Karpenko.University.Backend.Domain.Course;

namespace Karpenko.University.Backend.Application.UseCases.GetCourses;

/// <summary>
/// Интерфейс для работы с курсами
/// </summary>
public interface ICourseRepository {
  /// <summary>
  /// Получения списка курсов
  /// </summary>
  Task<ICollection<CourseModel>> GetCoursesAsync(PaginationModel paginationModel, CancellationToken cancellationToken);
  
  /// <summary>
  /// Получение общего количества курсов
  /// </summary>
  Task<int> GetCoursesCountAsync(CancellationToken cancellationToken);
}
