using Karpenko.University.Backend.Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Karpenko.University.Backend.Persistence.Repositories;

/// <summary>
/// Общий абстрактный репозиторий
/// </summary>
public abstract class AbstractRepository<TDbContext>(TDbContext db) : IRepository where TDbContext : DbContext {
  /// <inheritdoc />
  public async Task<TResult> InTransactionAsync<TResult>(Func<Task<TResult>> action, CancellationToken cancellationToken) {
    await using var transaction = await db.Database.BeginTransactionAsync(cancellationToken);

    try {
      var result = await action();
      await transaction.CommitAsync(cancellationToken);
      return result;
    } catch {
      await transaction.RollbackAsync(cancellationToken);
      throw;
    }
  }

  /// <inheritdoc />
  public async Task InTransactionAsync(Func<Task> action, CancellationToken cancellationToken) {
    await using var transaction = await db.Database.BeginTransactionAsync(cancellationToken);

    try {
      await action();
      await transaction.CommitAsync(cancellationToken);
    } catch {
      await transaction.RollbackAsync(cancellationToken);
      throw;
    }
  }
}
