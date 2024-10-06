using Karpenko.University.Backend.Core.ResultPattern;

namespace Karpenko.University.Backend.Application.UseCases.GetStudentByEmail;

/// <summary>
/// Сценарий для поиска студента по почте
/// </summary>
public sealed class UseCase(IStudentRepository studentRepository) : AbstractAsyncUseCase<EntryData> {
  /// <inheritdoc />
  public override async Task<IResult> ExecuteAsync(CancellationToken cancellationToken) {
    if (EntryData.Email is null)
      return new Results.NotFound();

    var student = await studentRepository.GetStudentByEmail(EntryData.Email, cancellationToken);

    if (student is null)
      return new Results.NotFound();
    
    return new Results.Found(student);
  }
}
