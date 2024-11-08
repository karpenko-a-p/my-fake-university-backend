using Karpenko.University.Backend.Domain.Course;

namespace Karpenko.University.Backend.Application.UseCases.PayOrderById;

/// <summary>
/// Репозиторий для работы с курсами
/// </summary>
public interface ICourseRepository {
  /// <summary>
  /// Получение курса по идентификатору заказа
  /// </summary>
  Task<CourseModel?> GetCourseByOrderId(long orderId, CancellationToken cancellationToken);
}
