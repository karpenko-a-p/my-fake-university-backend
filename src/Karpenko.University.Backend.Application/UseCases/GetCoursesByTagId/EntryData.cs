using Karpenko.University.Backend.Application.Pagination;

namespace Karpenko.University.Backend.Application.UseCases.GetCoursesByTagId;

/// <summary>
/// Данные для поиска списка курсов по тэгу
/// </summary>
/// <param name="TagId">Идентификатор тэга</param>
/// <param name="Pagination">Пагинация</param>
public sealed record EntryData(
  long TagId,
  PaginationModel Pagination);
