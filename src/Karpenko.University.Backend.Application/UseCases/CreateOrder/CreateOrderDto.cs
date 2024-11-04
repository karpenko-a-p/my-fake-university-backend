using Karpenko.University.Backend.Domain.Course;
using Karpenko.University.Backend.Domain.Student;

namespace Karpenko.University.Backend.Application.UseCases.CreateOrder;

/// <summary>
/// Данные для создания записи заказа в БД
/// </summary>
/// <param name="Course">Курс (Товар)</param>
/// <param name="Student">Студент (Заказчик)</param>
/// <param name="Description">Комментарий</param>
public sealed record CreateOrderDto(
  CourseModel Course,
  StudentModel Student,
  string? Description);
