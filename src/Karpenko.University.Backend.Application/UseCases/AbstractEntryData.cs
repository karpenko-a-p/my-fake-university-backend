namespace Karpenko.University.Backend.Application.UseCases;

/// <summary>
/// Абстрактное хранилище входного значения
/// </summary>
public abstract class AbstractEntryData<TEntryData> where TEntryData : notnull {
  /// <summary>
  /// Входное значени (Закрытое поле)
  /// </summary>
  private TEntryData? _entryData;
  
  /// <summary>
  /// Входное значени (Свойство)
  /// </summary>
  protected TEntryData EntryData {
    get {
      ArgumentNullException.ThrowIfNull(_entryData);
      return _entryData;
    }
    private set {
      _entryData = value;
    }
  }

  /// <summary>
  /// Установить входное значение
  /// </summary>
  public virtual AbstractEntryData<TEntryData> SetEntryData(TEntryData entryData) {
    EntryData = entryData;
    return this;
  }
}
