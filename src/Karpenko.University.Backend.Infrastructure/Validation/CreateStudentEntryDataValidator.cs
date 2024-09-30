using Karpenko.University.Backend.Application.Validation;
using static Karpenko.University.Backend.Domain.Student.StudentModel;
using CreateStudent = Karpenko.University.Backend.Application.UseCases.CreateStudent;

namespace Karpenko.University.Backend.Infrastructure.Validation;

/// <summary>
/// Валидатор для данных для создания аккаунта студента
/// </summary>
internal sealed class CreateStudentEntryDataValidator : AbstractValidator<CreateStudent.EntryData> {
  /// <inheritdoc />
  protected override void ValidateModel(CreateStudent.EntryData model) {
    StringValidator(nameof(model.Email), model.Email)
      .NotEmpty()
      .LengthLowerThenOrEqual(EmailMaxLength)
      .Match(new(@"^\S+@\S+.\S+$"));

    StringValidator(nameof(model.Name), model.Name)
      .NotEmpty()
      .LengthLowerThenOrEqual(128)
      .Match(new(@"^[A-zЁА-Яа-яё ]+$"));

    StringValidator(nameof(model.Password), model.Password)
      .NotEmpty()
      .LengthGreaterThenOrEqual(8)
      .LengthLowerThenOrEqual(128);
  }
}
