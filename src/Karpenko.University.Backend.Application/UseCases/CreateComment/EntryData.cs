using Karpenko.University.Backend.Domain.CourseComment;

namespace Karpenko.University.Backend.Application.UseCases.CreateComment;

/// <summary>
/// Данные для создания нового комментария
/// </summary>
/// <param name="CourseId">Идентификатор курса</param>
/// <param name="CreatorId">Идентификатор создателя комментария</param>
/// <param name="Content">Содержание комментария</param>
/// <param name="Quality">Оценка автора комментария курсу</param>
public sealed record EntryData(
  long? CourseId,
  long? CreatorId,
  string? Content,
  CourseQuality? Quality);
