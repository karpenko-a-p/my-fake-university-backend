using Karpenko.University.Backend.Application.UseCases.GenerateJwtToken;
using Karpenko.University.Backend.Application.Validation;
using static Karpenko.University.Backend.Domain.Student.StudentModel;

namespace Karpenko.University.Backend.Infrastructure.Validation;

/// <summary>
/// Валидатор данных для генерации jwt токена
/// </summary>
public sealed class GenerateJwtTokenEntryDataValidator : AbstractValidator<EntryData> {
  /// <inheritdoc />
  protected override void ValidateModel(EntryData model) {
    NumberValidator(nameof(model.Id), model.Id.GetValueOrDefault())
      .NotNull()
      .NotEmpty();
    
    StringValidator(nameof(model.Email), model.Email)
      .NotNull()
      .NotEmpty()
      .LengthLowerThenOrEqual(EmailMaxLength);
  }
}
