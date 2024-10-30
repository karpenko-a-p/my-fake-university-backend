using Karpenko.University.Backend.Application.Pagination;
using Karpenko.University.Backend.Domain.CourseComment;

namespace Karpenko.University.Backend.Application.UseCases.GetCommentsByAuthorId;

/// <summary>
/// Репозиторий для работы с комментариями
/// </summary>
public interface ICommentRepository {
  /// <summary>
  /// Получение комментариев студента по идентификатору
  /// </summary>
  Task<ICollection<CourseCommentModel>> GetCommentsByAuthorIdAsync(
    long authorId,
    PaginationModel pagination,
    CancellationToken cancellationToken);

  /// <summary>
  /// Получение количества комментариев студента по идентификатору
  /// </summary>
  Task<int> GetCommentsCountByAuthorIdAsync(long authorId, CancellationToken cancellationToken);
}
