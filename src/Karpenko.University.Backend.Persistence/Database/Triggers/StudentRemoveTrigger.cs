using EntityFrameworkCore.Triggered;
using Karpenko.University.Backend.Persistence.Database.Contexts;
using Karpenko.University.Backend.Persistence.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Karpenko.University.Backend.Persistence.Database.Triggers;

/// <summary>
/// Триггер на удаление записи аккаунта студента 
/// </summary>
internal sealed class StudentRemoveTrigger(PostgresDbContext dbContext) : IAfterSaveTrigger<StudentEntity> {
  /// <inheritdoc />
  public async Task AfterSave(ITriggerContext<StudentEntity> context, CancellationToken cancellationToken) {
    if (context.ChangeType == ChangeType.Deleted) {
      // удаление всех прав связанных с удаленным аккаунтом студента
      await dbContext.Permissions
        .Where(permission => permission.OwnerId == context.Entity.Id ||
                             permission.SubjectId == context.Entity.Id)
        .ExecuteDeleteAsync(cancellationToken);
    }
  }
}
