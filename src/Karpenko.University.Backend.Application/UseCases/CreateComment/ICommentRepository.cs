using Karpenko.University.Backend.Domain.CourseComment;

namespace Karpenko.University.Backend.Application.UseCases.CreateComment;

/// <summary>
/// Репозиторий для работы с комментариями
/// </summary>
public interface ICommentRepository {
  /// <summary>
  /// Создания нового комментария
  /// </summary>
  Task<CourseCommentModel> CreateCommentAsync(CreateCommentDto createCommentDto, CancellationToken cancellationToken);
}
