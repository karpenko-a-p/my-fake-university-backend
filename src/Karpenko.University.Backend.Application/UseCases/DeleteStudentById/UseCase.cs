using Karpenko.University.Backend.Core.ResultPattern;

namespace Karpenko.University.Backend.Application.UseCases.DeleteStudentById;

/// <summary>
/// Удаление студента по идентификатору
/// </summary>
public sealed class UseCase(IStudentRepository studentRepository) : AbstractAsyncUseCase<EntryData> {
  /// <inheritdoc />
  public override async Task<IResult> ExecuteAsync(CancellationToken cancellationToken) {
    var deleted = await studentRepository.DeleteStudentByIdAsync(EntryData.StudentId, cancellationToken);

    return deleted
      ? new Results.Deleted()
      : new Results.NotDeleted();
  }
}

