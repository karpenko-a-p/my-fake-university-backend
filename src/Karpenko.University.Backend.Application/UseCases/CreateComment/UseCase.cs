using Karpenko.University.Backend.Application.Validation;
using Karpenko.University.Backend.Core.ResultPattern;
using Karpenko.University.Backend.Domain.CourseComment;

namespace Karpenko.University.Backend.Application.UseCases.CreateComment;

/// <summary>
/// Сценарий создания комментария к курсу
/// </summary>
public sealed class UseCase(
  ICourseRepository courseRepository,
  ICommentRepository commentRepository,
  IValidator<EntryData> entryDataValidator
) : AbstractAsyncUseCase<EntryData> {
  /// <inheritdoc />
  public override async Task<IResult> ExecuteAsync(CancellationToken cancellationToken) {
    var validationResult = entryDataValidator.Validate(EntryData);

    if (validationResult.IsFailure)
      return new Validation.Results.ValidationFailure(validationResult);
    
    var courseExists = await courseRepository.CheckCourseExistsByIdAsync(
      EntryData.CourseId.GetValueOrDefault(),
      cancellationToken);

    if (!courseExists)
      return new Results.CourseNotFound();

    var createCommentDto = new CreateCommentDto(
      EntryData.CourseId.GetValueOrDefault(),
      EntryData.CreatorId.GetValueOrDefault(),
      EntryData.Content!,
      (CourseQuality)EntryData.Quality!);

    var comment = await commentRepository.CreateCommentAsync(createCommentDto, cancellationToken);

    return new Results.Created(comment);
  }
}
