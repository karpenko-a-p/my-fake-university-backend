using Karpenko.University.Backend.Application.Validation;
using Karpenko.University.Backend.Core.ResultPattern;

namespace Karpenko.University.Backend.Application.UseCases.GetCourseVideo;

/// <summary>
/// Сценарий получения части видео курса
/// </summary>
public sealed class UseCase(
  IVideoService videoService,
  ICourseContentRepository courseContentRepository,
  IValidator<EntryData> entryDataValidator
) : AbstractAsyncUseCase<EntryData> {
  /// <inheritdoc />
  public override async Task<IResult> ExecuteAsync(CancellationToken cancellationToken) {
    var validationResult = entryDataValidator.Validate(EntryData);

    if (validationResult.IsFailure)
      return new Validation.Results.ValidationFailure(validationResult);

    var courseContent = await courseContentRepository.GetCourseContentCourseIdAsync(
      EntryData.CourseId,
      cancellationToken);

    if (courseContent is null)
      return new Results.CourseNotFound();

    var videoFile = videoService.GetVideoFile(courseContent.VideoFileName);

    if (!videoFile.Exists)
      return new Results.VideoNotFound();

    var fileExtension = videoFile.Extension.Replace(".", "");
    var videoPartStart = EntryData.VideoPartStart >= videoFile.Length ? videoFile.Length : EntryData.VideoPartStart;
    var videoPartEnd = EntryData.VideoPartEnd >= videoFile.Length ? videoFile.Length : EntryData.VideoPartEnd;
    
    if (videoPartStart == videoPartEnd) {
      var fullFileStream = new FileStream(videoFile.FullName, FileMode.Open, FileAccess.Read);
      return new Results.File(fullFileStream, fileExtension);
    }
    
    var videoPartLength = videoPartEnd - videoPartStart;
    var stream = new FileStream(videoFile.FullName, FileMode.Open, FileAccess.Read);

    stream.Seek(videoPartStart, SeekOrigin.Begin);

    return new Results.FilePart(
      stream,
      videoPartStart,
      videoPartEnd,
      videoPartLength,
      videoFile.Length,
      fileExtension);
  }
}
