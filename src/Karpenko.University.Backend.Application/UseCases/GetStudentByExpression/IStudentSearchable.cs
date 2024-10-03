namespace Karpenko.University.Backend.Application.UseCases.GetStudentByExpression;

/// <summary>
/// Интерфейс с полями модели студента с помощью которых, можно найти студента
/// </summary>
public interface IStudentSearchable {
  /// <summary>
  /// Идентификатор
  /// </summary>
  ulong Id { get; }

  /// <summary>
  /// Почта
  /// </summary>
  string Email { get; }
}
