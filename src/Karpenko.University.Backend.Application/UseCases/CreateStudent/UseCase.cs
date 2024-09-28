using Karpenko.University.Backend.Application.Validation;
using Karpenko.University.Backend.Core.ResultPattern;

namespace Karpenko.University.Backend.Application.UseCases.CreateStudent;

/// <summary>
/// Создание нового аккаунта студента
/// </summary>
public sealed class UseCase(
  IStudentRepository studentRepository,
  IValidator<EntryData> entryDataValidator,
  IPasswordService passwordService
) : AbstractAsyncUseCase<EntryData> {
  /// <inheritdoc />
  public override async Task<IResult> ExecuteAsync(CancellationToken cancellationToken) {
    if (EntryData is null)
      return new Results.EmptyData();
    
    var validationResult = entryDataValidator.Validate(EntryData);
    
    if (validationResult.IsFailure)
      return new Results.ValidationError(validationResult);

    if (await studentRepository.CheckStudentExistsByEmailAsync(EntryData.Email!, cancellationToken)) 
      return new Results.StudentAlreadyExists();
    
    var hashedPassword = passwordService.HashPassword(EntryData.Password!);

    var createStudentDto = new CreateStudentDto(
      EntryData.Name!,
      EntryData.Email!,
      hashedPassword);
    
    var studentModel = await studentRepository.CreateStudentAsync(createStudentDto, cancellationToken);

    return new Results.StudentCreated(studentModel);
  }
}
