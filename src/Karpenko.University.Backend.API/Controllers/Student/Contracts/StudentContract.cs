using Karpenko.University.Backend.Domain.Student;

namespace Karpenko.University.Backend.API.Controllers.Student.Contracts;

/// <summary>
/// Контракт данных студента
/// </summary>
/// <param name="Id">Идентификатор</param>
/// <param name="Name">Имя</param>
/// <param name="Email">Почта</param>
/// <param name="AvatarUrl">Ссылка на фото</param>
/// <param name="RegistrationDate">Дата регистрации</param>
public sealed record StudentContract(
  ulong Id,
  string Name,
  string Email,
  string AvatarUrl,
  DateTime RegistrationDate
) {
  /// <summary>
  /// Получение контракта из модели студента
  /// </summary>
  public StudentContract(StudentModel studentModel) : this(
    studentModel.Id,
    studentModel.Name,
    studentModel.Email,
    studentModel.AvatarUrl,
    studentModel.RegistrationDate) {}
};
