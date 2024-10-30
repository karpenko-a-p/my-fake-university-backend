namespace Karpenko.University.Backend.Application.UseCases.CreateComment;

/// <summary>
/// Репозиторий для работы с курсами
/// </summary>
public interface ICourseRepository {
  /// <summary>
  /// Проверка, что курс с переданным идентификатором существует
  /// </summary>
  Task<bool> CheckCourseExistsByIdAsync(long courseId, CancellationToken cancellationToken);
}
