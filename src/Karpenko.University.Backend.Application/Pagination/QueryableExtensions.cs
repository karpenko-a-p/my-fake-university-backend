namespace Karpenko.University.Backend.Application.Pagination;

/// <summary>
/// Расширения для запросов 
/// </summary>
public static class QueryableExtensions {
  /// <summary>
  /// Добавление пагинации к запросу
  /// </summary>
  public static IQueryable<TItem> Paginate<TItem>(this IQueryable<TItem> query, int pageNumber, int pageSize) {
    return query.Skip(pageNumber * pageSize).Take(pageSize);
  }
  
  /// <summary>
  /// Добавление пагинации к запросу
  /// </summary>
  public static IQueryable<TItem> Paginate<TItem>(this IQueryable<TItem> query, PaginationModel pagination) {
    return query.Paginate(pagination.PageNumber, pagination.PageSize);
  }
}
