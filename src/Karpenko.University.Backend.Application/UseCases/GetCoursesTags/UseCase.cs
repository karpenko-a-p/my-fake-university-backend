using Karpenko.University.Backend.Core.ResultPattern;

namespace Karpenko.University.Backend.Application.UseCases.GetCoursesTags;

/// <summary>
/// Сценарий получения списка всех тэгов
/// </summary>
public sealed class UseCase(ITagRepository tagRepository, ICacheService cacheService) : IAsyncUseCase {
  /// <inheritdoc />
  public async Task<IResult> ExecuteAsync(CancellationToken cancellationToken) {
    var cachedTags = await cacheService.GetFromCacheAsync(cancellationToken);

    if (cachedTags is not null)
      return new Results.TagsCollection(cachedTags);

    var tags = await tagRepository.GetCoursesTagsAsync(cancellationToken);

    await cacheService.SetToCacheAsync(tags, cancellationToken);

    return new Results.TagsCollection(tags);
  }
}
