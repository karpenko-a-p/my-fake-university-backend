namespace Karpenko.University.Backend.Core.CommandPattern;

/// <summary>
/// Асинхронная команда
/// </summary>
public interface IAsyncCommand {
  /// <summary>
  /// Выполнение асинхронной команды
  /// </summary>
  Task ExecuteAsync(CancellationToken cancellationToken);
}

/// <summary>
/// Асинхронная команда с результатом
/// </summary>
public interface IAsyncCommand<TResult> {
  /// <summary>
  /// Выполнение асинхронной команды
  /// </summary>
  Task<TResult> ExecuteAsync(CancellationToken cancellationToken);
}
