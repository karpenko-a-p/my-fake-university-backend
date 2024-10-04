using Karpenko.University.Backend.Application.Validation;
using Karpenko.University.Backend.Core.ResultPattern;

namespace Karpenko.University.Backend.Application.UseCases.VerifyStudentPassword;

/// <summary>
/// Сценарий верификации пароля студента
/// </summary>
public sealed class UseCase(
  IValidator<EntryData> validator,
  IStudentRepository studentRepository,
  IPasswordService passwordService
) : AbstractAsyncUseCase<EntryData> {
  /// <inheritdoc />
  public override async Task<IResult> ExecuteAsync(CancellationToken cancellationToken) {
    var validationResult = validator.Validate(EntryData);

    if (validationResult.IsFailure)
      return new Results.ValidationError(validationResult);
    
    var userHashedPassword = await studentRepository.GetStudentPasswordByIdAsync(
      EntryData.Id.GetValueOrDefault(),
      cancellationToken);

    if (userHashedPassword is null)
      return new Results.StudentNotFound();

    if (passwordService.VerifyPasswords(EntryData.Password!, userHashedPassword))
      return new Results.PasswordVerified();
    
    return new Results.PasswordsDontMatch();
  }
}
