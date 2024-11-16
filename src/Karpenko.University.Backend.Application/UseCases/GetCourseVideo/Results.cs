using Karpenko.University.Backend.Core.ResultPattern;

namespace Karpenko.University.Backend.Application.UseCases.GetCourseVideo;

/// <summary>
/// Результаты сценария получения части видео курса
/// </summary>
public static class Results {
  /// <summary>
  /// Видео
  /// </summary>
  public sealed record File(FileStream Stream, string FileExt) : IResult;

  /// <summary>
  /// Часть видео
  /// </summary>
  public sealed record FilePart(
    FileStream Stream,
    long PartStart,
    long PartEnd,
    long PartLength,
    long FileSize,
    string FileExt) : IResult;
  
  /// <summary>
  /// Видео курса не найдено
  /// </summary>
  public sealed record VideoNotFound : IResult;
  
  /// <summary>
  /// Курс не найден
  /// </summary>
  public sealed record CourseNotFound : IResult;
}
