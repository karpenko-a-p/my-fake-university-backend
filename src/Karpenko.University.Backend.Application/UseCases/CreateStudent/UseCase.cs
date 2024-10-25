using Karpenko.University.Backend.Application.Validation;
using Karpenko.University.Backend.Core.ResultPattern;
using Karpenko.University.Backend.Domain.Permission;
using Karpenko.University.Backend.Domain.Student;

namespace Karpenko.University.Backend.Application.UseCases.CreateStudent;

/// <summary>
/// Создание нового аккаунта студента
/// </summary>
public sealed class UseCase(
  IStudentRepository studentRepository,
  IValidator<EntryData> entryDataValidator,
  IPasswordService passwordService,
  IPermissionRepository permissionRepository
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
      
      var passwordSavingTask = studentRepository.SaveStudentPasswordAsync(studentModel.Id, hashedPassword, cancellationToken);
      
      var permissionCreatingTask = permissionRepository.AddPermissionsToStudentAsync([
        GetBaseStudentPermission(studentModel.Id, PermissionType.Delete),
        GetBaseStudentPermission(studentModel.Id, PermissionType.Update)
      ], cancellationToken);

      await passwordSavingTask;
      await permissionCreatingTask;

      return studentModel;
    }, cancellationToken);

    return new Results.StudentCreated(student);
  }

  /// <summary>
  /// Формирование доступа студента к своей же записи
  /// </summary>
  private static PermissionModel GetBaseStudentPermission(long studentId, PermissionType permissionType) {
    return new() {
      OwnerId = studentId,
      SubjectId = studentId,
      PermissionType = permissionType
    };
  }
}
