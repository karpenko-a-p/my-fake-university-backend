using Karpenko.University.Backend.Core.ResultPattern;

namespace Karpenko.University.Backend.Application.UseCases.GetTagsByCourseId;

/// <summary>
/// Сценарий для получения всех тэгов по определенному курсу
/// </summary>
public sealed class UseCase(ITagRepository tagRepository) : AbstractAsyncUseCase<long> {
  /// <inheritdoc />
  public override async Task<IResult> ExecuteAsync(CancellationToken cancellationToken) {
    var tags = await tagRepository.GetTagsByCourseIdAsync(EntryData, cancellationToken);

    return new Results.TagsCollection(tags);
  }
}
