using Karpenko.University.Backend.Domain.CourseContent;

namespace Karpenko.University.Backend.Application.UseCases.GetCourseVideo;

/// <summary>
/// Репозиторий для работы с контентом курсов (видео)
/// </summary>
public interface ICourseContentRepository {
  /// <summary>
  /// Получение контента куса по идентификатору курса
  /// </summary>
  Task<CourseContentModel?> GetCourseContentCourseIdAsync(long courseId, CancellationToken cancellationToken);
}
