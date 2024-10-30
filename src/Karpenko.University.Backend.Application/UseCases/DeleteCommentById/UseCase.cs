using Karpenko.University.Backend.Core.ResultPattern;

namespace Karpenko.University.Backend.Application.UseCases.DeleteCommentById; 

/// <summary>
/// Сценарий для удаления комментария по идентификатору
/// </summary>
public sealed class UseCase(ICommentRepository commentRepository) : AbstractAsyncUseCase<long> {
  /// <inheritdoc />
  public override async Task<IResult> ExecuteAsync(CancellationToken cancellationToken) {
    var comment = await commentRepository.GetCommentByIdAsync(EntryData, cancellationToken);

    if (comment is null)
      return new Results.NotFound();

    await commentRepository.DeleteCourseByIdAsync(EntryData, cancellationToken);

    return new Results.Deleted(comment);
  }
}
