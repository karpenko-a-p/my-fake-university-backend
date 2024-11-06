using Karpenko.University.Backend.Domain.CourseComment;

namespace Karpenko.University.Backend.Application.UseCases.DeleteCommentById;

/// <summary>
/// Репозиторий для работы с комментариями
/// </summary>
public interface ICommentRepository {
  /// <summary>
  /// Получение комментария по идентификатору
  /// </summary>
  Task<CourseCommentModel?> GetCommentByIdAsync(long id, CancellationToken cancellationToken);

  /// <summary>
  /// Удаление комментария по идентификатору
  /// </summary>
  Task DeleteCommentByIdAsync(long id, CancellationToken cancellationToken);
}
