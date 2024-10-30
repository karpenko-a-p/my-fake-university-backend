using Karpenko.University.Backend.Application.Validation;
using CheckAccess = Karpenko.University.Backend.Application.UseCases.CheckAccess;

namespace Karpenko.University.Backend.Infrastructure.Validation;

/// <summary>
/// Валидатор данных для проверки прав доступа
/// </summary>
internal sealed class CheckAccessEntryDataValidator : AbstractValidator<CheckAccess.EntryData> {
  /// <inheritdoc />
  protected override void ValidateModel(CheckAccess.EntryData model) {
    NumberValidator(nameof(model.OwnerId), model.OwnerId.GetValueOrDefault())
      .NotNull()
      .NotEmpty();
    
    NumberValidator(nameof(model.SubjectId), model.SubjectId.GetValueOrDefault())
      .NotNull()
      .NotEmpty();
  }
}
