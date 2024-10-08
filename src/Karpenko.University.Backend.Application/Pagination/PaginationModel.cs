namespace Karpenko.University.Backend.Application.Pagination;

/// <summary>
/// Модель пагинации
/// </summary>
public sealed class PaginationModel {
  /// <summary>
  /// Номер страницы с данными
  /// </summary>
  private int _pageNumber;
  
  /// <summary>
  /// Размер страницы с данными
  /// </summary>
  private int _pageSize = 20;

  /// <summary>
  /// Номер страницы с данными
  /// </summary>
  public int PageNumber {
    get => _pageNumber;
    set {
      ArgumentOutOfRangeException.ThrowIfNegative(value);
      _pageNumber = value;
    }
  }

  /// <summary>
  /// Размер страницы с данными
  /// </summary>
  public int PageSize {
    get => _pageSize;
    set {
      ArgumentOutOfRangeException.ThrowIfNegative(value);
      _pageSize = value;
    }
  }
}
