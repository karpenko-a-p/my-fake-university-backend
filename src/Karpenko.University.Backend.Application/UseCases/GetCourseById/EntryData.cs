namespace Karpenko.University.Backend.Application.UseCases.GetCourseById;

/// <summary>
/// Данные для получения курса по идентификатору
/// </summary>
/// <param name="CourseId">Идентификатор курса</param>
public sealed record EntryData(
  long? CourseId);
