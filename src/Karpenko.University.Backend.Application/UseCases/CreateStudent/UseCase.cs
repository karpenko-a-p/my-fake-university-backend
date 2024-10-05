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
    var validationResult = entryDataValidator.Validate(EntryData);
    
    if (validationResult.IsFailure)
      return new Results.ValidationError(validationResult);

    if (await studentRepository.CheckStudentExistsByEmailAsync(EntryData.Email!, cancellationToken)) 
      return new Results.StudentAlreadyExists();
    
    var hashedPassword = passwordService.HashPassword(EntryData.Password!);

    var createStudentDto = new CreateStudentDto(EntryData.Name!, EntryData.Email!);
    
    var student = await studentRepository.InTransactionAsync(async () => {
      var studentModel = await studentRepository.CreateStudentAsync(createStudentDto, cancellationToken);
      
      await studentRepository.SaveStudentPasswordAsync(studentModel.Id, hashedPassword, cancellationToken);

      return studentModel;
    }, cancellationToken);

    return new Results.StudentCreated(student);
  }
}
