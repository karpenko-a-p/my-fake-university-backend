using Karpenko.University.Backend.Application.Validation;
using Karpenko.University.Backend.Core.ResultPattern;

namespace Karpenko.University.Backend.Application.UseCases.GetCourseById;

/// <summary>
/// Получение данных по курсу по идентификатору
/// </summary>
public sealed class UseCase(ICourseRepository courseRepository, IValidator<EntryData> validator) : AbstractAsyncUseCase<EntryData> {
  /// <inheritdoc />
  public override async Task<IResult> ExecuteAsync(CancellationToken cancellationToken) {
    var validationResult = validator.Validate(EntryData);

    if (validationResult.IsFailure)
      return new Validation.Results.ValidationFailure(validationResult);
    
    var course = await courseRepository.GetCourseByIdAsync(
      EntryData.CourseId.GetValueOrDefault(),
      cancellationToken);
    
    if (course is null)
      return new Results.NotFound();
    
    return new Results.Found(course);
  }
}
