using Karpenko.University.Backend.Domain.CourseTag;

namespace Karpenko.University.Backend.Application.UseCases.GetCoursesTags;

/// <summary>
/// Репозиторий для работы с тэгами курсов
/// </summary>
public interface ITagRepository {
  /// <summary>
  /// Получение списка всех тэгов
  /// </summary>
  Task<ICollection<CourseTagModel>> GetCoursesTagsAsync(CancellationToken cancellationToken);
}
