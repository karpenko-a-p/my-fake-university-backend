namespace Karpenko.University.Backend.Application.UseCases;

/// <summary>
/// Абстрактное хранилище входного значения
/// </summary>
public abstract class AbstractEntryData<TEntryData> {
  /// <summary>
  /// Входное значени
  /// </summary>
  protected TEntryData? EntryData { get; private set; }

  /// <summary>
  /// Установить входное значение
  /// </summary>
  public virtual AbstractEntryData<TEntryData> SetEntryData(TEntryData? entryData) {
    EntryData = entryData;
    return this;
  }
}
