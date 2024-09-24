namespace Karpenko.University.Backend.Core.CommandPattern;

/// <summary>
/// Команда
/// </summary>
public interface ICommand {
  /// <summary>
  /// Выполнить команду
  /// </summary>
  void Execute();
}

/// <summary>
/// Команда с результатом
/// </summary>
public interface ICommand<out TResult> {
  /// <summary>
  /// Выполнить команду
  /// </summary>
  TResult Execute();
}
