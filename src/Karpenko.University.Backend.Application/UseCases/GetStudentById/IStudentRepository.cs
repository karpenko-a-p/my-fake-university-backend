using Karpenko.University.Backend.Domain.Student;

namespace Karpenko.University.Backend.Application.UseCases.GetStudentById;

/// <summary>
/// Интерфейс для работы с данными студентами 
/// </summary>
public interface IStudentRepository {
  /// <summary>
  /// Поиск студента по идентификатору
  /// </summary>
  Task<StudentModel?> GetStudentByIdAsync(long id, CancellationToken cancellationToken);
}
