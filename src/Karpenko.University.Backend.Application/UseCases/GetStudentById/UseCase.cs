using Karpenko.University.Backend.Core.ResultPattern;

namespace Karpenko.University.Backend.Application.UseCases.GetStudentById;

/// <summary>
/// Сценарий поиска студента по идентификатору
/// </summary>
public sealed class UseCase(IStudentRepository studentRepository) : AbstractAsyncUseCase<EntryData> {
  /// <inheritdoc />
  public override async Task<IResult> ExecuteAsync(CancellationToken cancellationToken) {
    if (EntryData.Id is null)
      return new Results.NotFound();

    var student = await studentRepository.GetStudentByIdAsync(EntryData.Id.GetValueOrDefault(), cancellationToken);

    if (student is null)
      return new Results.NotFound();

    return new Results.Found(student);
  }
}
