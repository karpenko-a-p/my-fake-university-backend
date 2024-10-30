using Karpenko.University.Backend.Application.Pagination;

namespace Karpenko.University.Backend.Application.UseCases.GetCommentsByAuthorId;

/// <summary>
/// Данные для получения комментариев определенного студента
/// </summary>
/// <param name="AuthorId">Идентификатор студента</param>
/// <param name="Pagination">Данные пагинации</param>
public sealed record EntryData(
  long AuthorId,
  PaginationModel Pagination);
