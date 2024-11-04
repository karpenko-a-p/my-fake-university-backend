using Karpenko.University.Backend.Domain.Course;
using Karpenko.University.Backend.Domain.Student;

namespace Karpenko.University.Backend.Application.UseCases.CreateOrder;

/// <summary>
/// Входные данные для сценария создания заказа
/// </summary>
/// <param name="Student">Заказчика</param>
/// <param name="Course">Товар</param>
/// <param name="Description">Комментарий к заказу</param>
public sealed record EntryData(
  StudentModel Student,
  CourseModel Course,
  string? Description);
