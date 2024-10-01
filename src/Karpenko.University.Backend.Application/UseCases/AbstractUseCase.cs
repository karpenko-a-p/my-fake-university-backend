using Karpenko.University.Backend.Core.ResultPattern;

namespace Karpenko.University.Backend.Application.UseCases;

/// <summary>
/// Абстрактный сценарий использования
/// </summary>
public abstract class AbstractUseCase<TEntryData> : AbstractEntryData<TEntryData>, IUseCase where TEntryData : notnull {
  /// <inheritdoc />
  public abstract IResult Execute();

  /// <inheritdoc />
  public override AbstractUseCase<TEntryData> SetEntryData(TEntryData entryData) {
    base.SetEntryData(entryData);
    return this;
  }
}
