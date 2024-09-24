namespace Karpenko.University.Backend.Core.ResultPattern;

/// <summary>
/// Результат
/// </summary>
public interface IResult;

/// <summary>
/// Результат со значением
/// </summary>
public interface IResult<out TValue> {
  /// <summary>
  /// Значение результата
  /// </summary>
  TValue Value { get; }
}
