using Karpenko.University.Backend.Application.Validation;
using AddAccess = Karpenko.University.Backend.Application.UseCases.AddAccess;

namespace Karpenko.University.Backend.Infrastructure.Validation;

/// <summary>
/// Валидатор данных для создания прав
/// </summary>
internal sealed class AddAccessEntryDataValidator : AbstractValidator<AddAccess.EntryData> {
  /// <inheritdoc />
  protected override void ValidateModel(AddAccess.EntryData model) {
    NumberValidator(nameof(model.OwnerId), model.OwnerId.GetValueOrDefault())
      .NotEmpty()
      .NotNull();

    NumberValidator(nameof(model.SubjectId), model.SubjectId.GetValueOrDefault())
      .NotEmpty()
      .NotNull();
  }
}
