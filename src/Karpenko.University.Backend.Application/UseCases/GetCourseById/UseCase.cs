using Karpenko.University.Backend.Core.ResultPattern;

namespace Karpenko.University.Backend.Application.UseCases.GetCourseById;

/// <summary>
/// Получение данных по курсу по идентификатору
/// </summary>
public sealed class UseCase(ICourseRepository courseRepository) : AbstractAsyncUseCase<long> {
  /// <inheritdoc />
  public override async Task<IResult> ExecuteAsync(CancellationToken cancellationToken) {
    var course = await courseRepository.GetCourseByIdAsync(EntryData, cancellationToken);
    
    if (course is null)
      return new Results.NotFound();
    
    return new Results.Found(course);
  }
}
