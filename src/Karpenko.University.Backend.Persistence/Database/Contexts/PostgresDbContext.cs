﻿using Karpenko.University.Backend.Persistence.Database.Entities.Course;
using Karpenko.University.Backend.Persistence.Database.Entities.CourseComment;
using Karpenko.University.Backend.Persistence.Database.Entities.CourseContent;
using Karpenko.University.Backend.Persistence.Database.Entities.CourseTag;
using Karpenko.University.Backend.Persistence.Database.Entities.Order;
using Karpenko.University.Backend.Persistence.Database.Entities.Permission;
using Karpenko.University.Backend.Persistence.Database.Entities.Student;
using Karpenko.University.Backend.Persistence.Database.Entities.StudentPassword;
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

  /// <summary>
  /// Таблица с правами
  /// </summary>
  public DbSet<PermissionEntity> Permissions { get; set; } = null!;

  /// <summary>
  /// Таблица с курсами
  /// </summary>
  public DbSet<CourseEntity> Courses { get; set; } = null!;

  /// <summary>
  /// Таблица с тэгами курсов
  /// </summary>
  public DbSet<CourseTagEntity> Tags { get; set; } = null!;
  
  /// <summary>
  /// Таблица с комментариями курсов
  /// </summary>
  public DbSet<CourseCommentEntity> Comments { get; set; } = null!;
  
  /// <summary>
  /// Таблица с заказами
  /// </summary>
  public DbSet<OrderEntity> Orders { get; set; } = null!;

  /// <summary>
  /// Таблица с контентом курсов
  /// </summary>
  public DbSet<CourseContentEntity> Content { get; set; } = null!;

  /// <inheritdoc />
  protected override void OnModelCreating(ModelBuilder modelBuilder) {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostgresDbContext).Assembly);
    modelBuilder.HasDefaultSchema(Schemas.UniversityBackend);
  }
}
