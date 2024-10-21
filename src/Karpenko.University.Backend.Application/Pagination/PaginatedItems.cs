namespace Karpenko.University.Backend.Application.Pagination;

/// <summary>
/// Модель списка с данными пагинации
/// </summary>
/// <param name="Items">Список элементов</param>
/// <param name="TotalItems">Всего элементов</param>
/// <param name="PageNumber">Номер страницы</param>
/// <param name="PageSize">Размер страницы</param>
public sealed record PaginatedItems<TItem>(
  ICollection<TItem> Items,
  int TotalItems,
  int PageNumber,
  int PageSize
) {
  /// <summary>
  /// Количество страниц
  /// </summary>
  public int TotalPages => (int)Math.Ceiling(TotalItems / (double)PageSize);

  /// <summary>
  /// Есть ли следующая страница
  /// </summary>
  public bool HasNext => (PageNumber + 1) < TotalPages;

  /// <summary>
  /// Есть ли предыдущая страница
  /// </summary>
  public bool HasPrev => PageNumber > 0 && PageNumber < TotalPages;

  /// <summary>
  /// Маппинг данных пагинированной коллекции
  /// </summary>
  public PaginatedItems<TNewItem> Map<TNewItem>(Func<TItem, TNewItem> mapper) {
    return new(
      Items: Items.Select(mapper).ToArray(),
      TotalItems: TotalItems,
      PageNumber: PageNumber,
      PageSize: PageSize);
  }
}
