using Karpenko.University.Backend.Application.Pagination;

namespace Karpenko.University.Backend.Application.UseCases.GetCommentsByCourseId;

/// <summary>
/// Сервис для работы с кэшем комментариев
/// </summary>
public interface ICacheService {
  /// <summary>
  /// Получение данных из кэша
  /// </summary>
  Task<PaginatedItems<CommentWithAuthorDto>?> GetFromCacheAsync(long courseId, PaginationModel pagination, CancellationToken cancellationToken);

  /// <summary>
  /// Сохранение данных в кэш
  /// </summary>
  Task SetToCacheAsync(long courseId, PaginatedItems<CommentWithAuthorDto> model, CancellationToken cancellationToken);
}
