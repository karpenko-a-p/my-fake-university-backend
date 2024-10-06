using Karpenko.University.Backend.Domain.Student;

namespace Karpenko.University.Backend.Application.UseCases.GetStudentByEmail;

/// <summary>
/// Интерфейс для работы с данными студентами 
/// </summary>
public interface IStudentRepository {
  /// <summary>
  /// Поиск студента по почте
  /// </summary>
  Task<StudentModel?> GetStudentByEmailAsync(string email, CancellationToken cancellationToken);
}
