using Karpenko.University.Backend.Core.ResultPattern;

namespace Karpenko.University.Backend.Application.UseCases;

/// <summary>
/// Абстрактный асинхронный сценарий использования
/// </summary>
public abstract class AbstractAsyncUseCase<TEntryData> : AbstractEntryData<TEntryData>, IAsyncUseCase where TEntryData : notnull {
  /// <inheritdoc />
  public abstract Task<IResult> ExecuteAsync(CancellationToken cancellationToken);

  /// <inheritdoc />
  public override AbstractAsyncUseCase<TEntryData> SetEntryData(TEntryData entryData) {
    base.SetEntryData(entryData);
    return this;
  }
}
