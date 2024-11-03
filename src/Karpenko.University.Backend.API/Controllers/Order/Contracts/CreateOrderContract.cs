namespace Karpenko.University.Backend.API.Controllers.Order.Contracts;

/// <summary>
/// Контракт данных для создания заказа
/// </summary>
/// <param name="Description">Комментарий к заказу</param>
/// <param name="CourseId">Идентификатор курса</param>
public sealed record CreateOrderContract(
  string Description,
  long CourseId);
