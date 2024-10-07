using Karpenko.University.Backend.Core.ResultPattern;
using Karpenko.University.Backend.Domain.Permission;

namespace Karpenko.University.Backend.Application.UseCases.AddAccess;

/// <summary>
/// Возможные результаты для сценария предоставления доступа
/// </summary>
public static class Results {
  /// <summary>
  /// Доступ предоставлен
  /// </summary>
  public sealed record Success(PermissionModel Permission) : IResult;
}
