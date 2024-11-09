namespace Karpenko.University.Backend.Domain.Permission;

/// <summary>
/// Для чего предоставляется доступ
/// </summary>
public enum PermissionSubject : byte {
  /// <summary>
  /// Курс
  /// </summary>
  Course = 1,

  /// <summary>
  /// Содержимое курса
  /// </summary>
  CourseContent,

  /// <summary>
  /// Комментарий
  /// </summary>
  Comment,

  /// <summary>
  /// Заказ
  /// </summary>
  Order,

  /// <summary>
  /// Студент
  /// </summary>
  Student
}
