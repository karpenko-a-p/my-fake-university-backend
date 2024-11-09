using Karpenko.University.Backend.Application.Pagination;

namespace Karpenko.University.Backend.Application.UseCases.GetOrdersByOwnerId;

/// <summary>
/// Данные для сценария посика заказов по заканзчика
/// </summary>
/// <param name="OwnerId"></param>
/// <param name="Pagination"></param>
public sealed record EntryData(
  long OwnerId,
  PaginationModel Pagination);
