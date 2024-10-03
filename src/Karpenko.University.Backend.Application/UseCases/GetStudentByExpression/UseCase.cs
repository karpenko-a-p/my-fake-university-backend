using Karpenko.University.Backend.Core.ResultPattern;

namespace Karpenko.University.Backend.Application.UseCases.GetStudentByExpression;

/// <summary>
/// Сценарий поиска студента по определенному критерию
/// </summary>
public sealed class UseCase(IStudentRepository studentRepository) : AbstractAsyncUseCase<StudentSearchStrategy> {
  /// <inheritdoc />
  public override async Task<IResult> ExecuteAsync(CancellationToken cancellationToken) {
    var student = await studentRepository.GetStudentByExpressionAsync(EntryData.SearchExpression, cancellationToken);

    if (student is null)
      return new Results.NotFound();

    return new Results.Found(student);
  }
}
