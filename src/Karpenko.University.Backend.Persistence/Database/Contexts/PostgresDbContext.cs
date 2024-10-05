using Microsoft.EntityFrameworkCore;

namespace Karpenko.University.Backend.Persistence.Database.Contexts;

/// <summary>
/// Контекст основной (и единственной) БД
/// </summary>
internal sealed class PostgresDbContext(DbContextOptions<PostgresDbContext> options) : DbContext(options) {
  public DbSet<string> Students { get; }

  /// <inheritdoc />
  protected override void OnModelCreating(ModelBuilder modelBuilder) {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostgresDbContext).Assembly);
    modelBuilder.HasDefaultSchema(Schemas.UniversityBackend);
  }
}
