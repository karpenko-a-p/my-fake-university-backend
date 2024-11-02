using Karpenko.University.Backend.Application.Pagination;

namespace Karpenko.University.Backend.Application.UseCases.GetCommentsByCourseId;

/// <summary>
/// Репозиторий для работы с комментариями
/// </summary>
public interface ICommentRepository {
  /// <summary>
  /// Получение списка комментариев по курсу
  /// </summary>
  Task<ICollection<CommentWithAuthorDto>> GetCommentsWithAuthorByCourseIdAsync(
    long courseId,
    PaginationModel pagination,
    CancellationToken cancellationToken);

  /// <summary>
  /// Получение количества комментариев курса по идентификатору
  /// </summary>
  Task<int> GetCommentsCountByCourseIdAsync(long courseId, CancellationToken cancellationToken);
}
