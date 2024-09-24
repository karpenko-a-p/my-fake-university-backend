namespace Karpenko.University.Backend.Core.ResultPattern;

/// <summary>
/// Параметризированный результат
/// </summary>
/// <typeparam name="TValue">Тип значения результата</typeparam>
public interface IValueResult<out TValue> : IResult {
  /// <summary>
  /// Значение результата
  /// </summary>
  TValue Value { get; }
}
