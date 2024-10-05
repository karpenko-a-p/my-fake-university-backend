namespace Karpenko.University.Backend.Application.Repositories;

/// <summary>
/// Общий интерфейс репозитория
/// </summary>
public interface IRepository {
  /// <summary>
  /// Выполнить действия с БД внутри транзакции
  /// </summary>
  Task<TResult> InTransactionAsync<TResult>(Func<Task<TResult>> action, CancellationToken cancellationToken);

  /// <summary>
  /// Выполнить действия с БД внутри транзакции без возвращения результата
  /// </summary>
  Task InTransactionAsync(Func<Task> action, CancellationToken cancellationToken);
}
