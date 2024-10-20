using Karpenko.University.Backend.Domain.Course;

namespace Karpenko.University.Backend.API.Controllers.Course.Contracts;

/// <summary>
/// Контракт данных курса
/// </summary>
/// <param name="Id">Идентификатор</param>
/// <param name="Name">Название</param>
/// <param name="Description">Описание</param>
/// <param name="LogoUrl">Лого курса</param>
/// <param name="CreationDate">Дата создания</param>
/// <param name="BoughtCount">Кол-во людей купивших курс</param>
public sealed record CourseContract(
  long Id,
  string Name,
  string Description,
  string LogoUrl,
  DateTime CreationDate,
  long BoughtCount
) {
  /// <summary>
  /// Получение контракта из модели курса
  /// </summary>
  public CourseContract(CourseModel courseModel) : this(
    courseModel.Id,
    courseModel.Name,
    courseModel.Description,
    courseModel.LogoUrl,
    courseModel.CreationDate,
    courseModel.BoughtCount
  ) {}
}
