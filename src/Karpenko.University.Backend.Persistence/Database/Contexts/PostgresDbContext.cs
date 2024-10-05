using Karpenko.University.Backend.Persistence.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Karpenko.University.Backend.Persistence.Database.Contexts;

/// <summary>
/// Контекст основной (и единственной) БД
/// </summary>
internal sealed class PostgresDbContext(DbContextOptions<PostgresDbContext> options) : DbContext(options) {
  /// <summary>
  /// Таблица студентов
  /// </summary>
  public DbSet<StudentEntity> Students { get; set; } = null!;
  
  /// <summary>
  /// Таблица паролей студентов
  /// </summary>
  public DbSet<StudentPasswordEntity> StudentsPasswords { get; set; } = null!;

  /// <inheritdoc />
  protected override void OnModelCreating(ModelBuilder modelBuilder) {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostgresDbContext).Assembly);
    modelBuilder.HasDefaultSchema(Schemas.UniversityBackend);
  }
}
