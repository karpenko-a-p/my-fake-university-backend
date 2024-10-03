using Karpenko.University.Backend.Domain.Student;

namespace Karpenko.University.Backend.Application.UseCases.GetStudentByExpression;

/// <summary>
/// Репозиторий для работы с данными студентов
/// </summary>
public interface IStudentRepository {
  /// <summary>
  /// Поиск студента по определенному критерию
  /// </summary>
  Task<StudentModel?> GetStudentByExpressionAsync(Func<IStudentSearchable, bool> expression, CancellationToken cancellationToken);
}
