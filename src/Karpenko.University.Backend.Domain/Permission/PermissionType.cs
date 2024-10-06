namespace Karpenko.University.Backend.Domain.Permission;

/// <summary>
/// Виды прав
/// </summary>
public enum PermissionType : byte {
  /// <summary>
  /// Создание
  /// </summary>
  Create,

  /// <summary>
  /// Чтение
  /// </summary>
  Read,

  /// <summary>
  /// Обновление
  /// </summary>
  Update,

  /// <summary>
  /// Удаление
  /// </summary>
  Delete
}
