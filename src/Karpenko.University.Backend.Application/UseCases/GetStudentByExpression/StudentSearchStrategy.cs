namespace Karpenko.University.Backend.Application.UseCases.GetStudentByExpression;

using SearchExpression = Func<IStudentSearchable, bool>;

/// <summary>
/// Стратегия поиска студента
/// </summary>
public class StudentSearchStrategy(SearchExpression searchExpression) {
  /// <summary>
  /// Геттер для стратегии
  /// </summary>
  public SearchExpression SearchExpression => searchExpression;
  
  /// <summary>
  /// Стратегия поиска через почту
  /// </summary>
  public static StudentSearchStrategy ByEmail(string email) => new(student => student.Email == email);
  
  /// <summary>
  /// Стратегия поиска через идентифкатор
  /// </summary>
  public static StudentSearchStrategy ById(ulong id) => new(student => student.Id == id);
}
