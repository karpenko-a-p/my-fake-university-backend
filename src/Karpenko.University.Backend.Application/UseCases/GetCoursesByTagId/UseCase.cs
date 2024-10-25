using Karpenko.University.Backend.Application.Pagination;
using Karpenko.University.Backend.Core.ResultPattern;

namespace Karpenko.University.Backend.Application.UseCases.GetCoursesByTagId;

/// <summary>
/// Сценарий получения всех курсов с определенным тэгом
/// </summary>
public sealed class UseCase(ICourseRepository courseRepository, ICacheService cacheService) : AbstractAsyncUseCase<EntryData> {
  /// <inheritdoc />
  public override async Task<IResult> ExecuteAsync(CancellationToken cancellationToken) {
    var cachedCourses = await cacheService.GetFromCacheAsync(EntryData.Pagination, cancellationToken);
    
    if (cachedCourses is not null)
      return new Results.CoursesCollection(cachedCourses);
    
    var courses = await courseRepository.GetCoursesByTagIdAsync(
      EntryData.TagId,
      EntryData.Pagination,
      cancellationToken);

    var totalCourses = await courseRepository.GetCoursesCountByTagIdAsync(
      EntryData.TagId,
      EntryData.Pagination,
      cancellationToken);

    var paginatedData = courses.ToPaginatedCollection(EntryData.Pagination, totalCourses);
    
    cacheService.SetToCacheAsync(paginatedData, cancellationToken);

    return new Results.CoursesCollection(paginatedData);
  }
}
