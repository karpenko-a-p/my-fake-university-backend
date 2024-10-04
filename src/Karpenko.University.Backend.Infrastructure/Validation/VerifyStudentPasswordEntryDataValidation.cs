using Karpenko.University.Backend.Application.Validation;
using VerifyStudentPassword = Karpenko.University.Backend.Application.UseCases.VerifyStudentPassword;

namespace Karpenko.University.Backend.Infrastructure.Validation;

/// <summary>
/// Валидатор данных для верификации пароля студента
/// </summary>
public sealed class VerifyStudentPasswordEntryDataValidation : AbstractValidator<VerifyStudentPassword.EntryData> {
  /// <inheritdoc />
  protected override void ValidateModel(VerifyStudentPassword.EntryData model) {
    NumberValidator(nameof(model.Id), model.Id.GetValueOrDefault())
      .NotNull()
      .NotEmpty();
    
    StringValidator(nameof(model.Password), model.Password)
      .NotEmpty()
      .LengthGreaterThenOrEqual(8)
      .LengthLowerThenOrEqual(128);
  }
}
