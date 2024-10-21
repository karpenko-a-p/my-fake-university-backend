using Karpenko.University.Backend.Domain.CourseTag;

namespace Karpenko.University.Backend.API.Controllers.Tag.Contracts;

/// <summary>
/// Контракт тэга курса
/// </summary>
/// <param name="Id">Идентификатор</param>
/// <param name="Name">Название</param>
public sealed record TagContract(
  long Id,
  string Name
) {
  /// <summary>
  /// Приведение модели к формату контракта
  /// </summary>
  public TagContract(CourseTagModel model) : this(
    model.Id,
    model.Name) {}
}
