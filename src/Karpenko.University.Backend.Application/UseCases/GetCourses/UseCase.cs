using Karpenko.University.Backend.Application.Pagination;
using Karpenko.University.Backend.Core.ResultPattern;

namespace Karpenko.University.Backend.Application.UseCases.GetCourses;

/// <summary>
/// Сценарий для получения списка курсов
/// </summary>
public sealed class UseCase(ICourseRepository courseRepository, ICacheService cacheService) : AbstractAsyncUseCase<PaginationModel> {
  /// <inheritdoc />
  public override async Task<IResult> ExecuteAsync(CancellationToken cancellationToken) {
    var cachedCourses = await cacheService.GetFromCacheAsync(EntryData, cancellationToken);

    if (cachedCourses is not null)
      return new Results.CoursesCollection(cachedCourses);
    
    var coursesCount = await courseRepository.GetCoursesCountAsync(cancellationToken);
    var courses = await courseRepository.GetCoursesAsync(EntryData, cancellationToken);

    var paginatedCourses = courses.ToPaginatedCollection(EntryData, coursesCount);

    await cacheService.SetToCacheAsync(paginatedCourses, cancellationToken);

    return new Results.CoursesCollection(paginatedCourses);
  }
}
