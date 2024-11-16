using Karpenko.University.Backend.Application.Validation;
using GetCourseVideo = Karpenko.University.Backend.Application.UseCases.GetCourseVideo;

namespace Karpenko.University.Backend.Infrastructure.Validation;

/**
 * Валидатор входных данных для получения видео курса 
 */
internal sealed class GetCourseVideoEntryDataValidator : AbstractValidator<GetCourseVideo.EntryData> {
  /// <inheritdoc />
  protected override void ValidateModel(GetCourseVideo.EntryData model) {
    NumberValidator(nameof(model.VideoPartStart), model.VideoPartStart)
      .GreaterThenOrEqual(0);

    NumberValidator(nameof(model.VideoPartEnd), model.VideoPartEnd)
      .GreaterThenOrEqual(0);
  }
}
