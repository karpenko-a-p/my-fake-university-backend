namespace Karpenko.University.Backend.Application.UseCases.DeleteCommentById;

/// <summary>
/// Сервис для работы с кэшем комментариев курсов
/// </summary>
public interface ICacheService {
  /// <summary>
  /// Очистка комментариев для курса
  /// </summary>
  Task ClearCacheByCourseIdAsync(long courseId, CancellationToken cancellationToken);
}
