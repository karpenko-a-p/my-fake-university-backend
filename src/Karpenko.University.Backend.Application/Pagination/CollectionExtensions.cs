namespace Karpenko.University.Backend.Application.Pagination;

/// <summary>
/// Расширения для списка
/// </summary>
public static class CollectionExtensions {
  /// <summary>
  /// Приведение списка к пагинированному списку
  /// </summary>
  public static PaginatedItems<TItem> ToPaginatedCollection<TItem>(this ICollection<TItem> array, PaginationModel pagination, int totalItems) {
    return new (
      Items: array,
      TotalItems: totalItems,
      PageNumber: pagination.PageNumber,
      PageSize: pagination.PageSize);
  }
}
