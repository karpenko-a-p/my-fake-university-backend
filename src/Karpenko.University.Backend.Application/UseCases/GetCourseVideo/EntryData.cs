namespace Karpenko.University.Backend.Application.UseCases.GetCourseVideo;

/// <summary>
/// Данные для получения фрагмента видео
/// </summary>
/// <param name="CourseId">Идентификатор курса</param>
/// <param name="VideoPartStart">Начало отрывка видео</param>
/// <param name="VideoPartEnd">Конец отрывка видео</param>
public sealed record EntryData(
  long CourseId,
  long VideoPartStart,
  long VideoPartEnd);
