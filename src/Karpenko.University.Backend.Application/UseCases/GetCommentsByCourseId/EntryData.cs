using Karpenko.University.Backend.Application.Pagination;

namespace Karpenko.University.Backend.Application.UseCases.GetCommentsByCourseId;

/// <summary>
/// Данные для получения комментариев курса
/// </summary>
/// <param name="CourseId">Идентификатор курса</param>
/// <param name="Pagination">Данные пагинации</param>
public sealed record EntryData(
  long CourseId,
  PaginationModel Pagination);
