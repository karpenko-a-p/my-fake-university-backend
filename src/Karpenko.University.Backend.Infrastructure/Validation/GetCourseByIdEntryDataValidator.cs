using Karpenko.University.Backend.Application.Validation;
using GetCourseById = Karpenko.University.Backend.Application.UseCases.GetCourseById;

namespace Karpenko.University.Backend.Infrastructure.Validation;

/// <summary>
/// Валидатор данных для получения курса
/// </summary>
internal sealed class GetCourseByIdEntryDataValidator : AbstractValidator<GetCourseById.EntryData> {
  /// <inheritdoc />
  protected override void ValidateModel(GetCourseById.EntryData model) {
    NumberValidator(nameof(model.CourseId), model.CourseId.GetValueOrDefault())
      .NotEmpty()
      .NotNull();
  }
}
