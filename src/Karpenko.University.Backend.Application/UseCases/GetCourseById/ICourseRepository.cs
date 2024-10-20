using Karpenko.University.Backend.Domain.Course;

namespace Karpenko.University.Backend.Application.UseCases.GetCourseById;

/// <summary>
/// Репозиторий для работы с данными курсов
/// </summary>
public interface ICourseRepository {
  /// <summary>
  /// Поиск курса по его идентификатору
  /// </summary>
  Task<CourseModel?> GetCourseByIdAsync(long id, CancellationToken cancellationToken);
}
