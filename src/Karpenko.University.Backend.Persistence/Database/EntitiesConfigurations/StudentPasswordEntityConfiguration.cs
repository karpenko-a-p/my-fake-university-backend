using Karpenko.University.Backend.Persistence.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Karpenko.University.Backend.Persistence.Database.EntitiesConfigurations;

/// <summary>
/// Конфигурация для таблицы с паролями студентов
/// </summary>
internal sealed class StudentPasswordEntityConfiguration : IEntityTypeConfiguration<StudentPasswordEntity> {
  /// <inheritdoc />
  public void Configure(EntityTypeBuilder<StudentPasswordEntity> builder) {
    builder.ToTable(Tables.StudentsPasswords);

    builder.HasKey(model => model.StudentId);
    
    builder.Property(model => model.StudentId)
      .HasColumnName("student_id")
      .IsRequired()
      .ValueGeneratedOnAdd();
    
    builder.Property(model => model.Password)
      .HasColumnName("password")
      .IsRequired()
      .HasColumnType("text");

    builder
      .HasOne(model => model.Student)
      .WithOne(student => student.Password)
      .HasForeignKey<StudentPasswordEntity>(student => student.StudentId)
      .OnDelete(DeleteBehavior.Cascade)
      .HasConstraintName("fk_student_password");
  }
}
