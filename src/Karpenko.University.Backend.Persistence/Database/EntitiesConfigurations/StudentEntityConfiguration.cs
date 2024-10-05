using Karpenko.University.Backend.Persistence.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Karpenko.University.Backend.Domain.Student.StudentModel;

namespace Karpenko.University.Backend.Persistence.Database.EntitiesConfigurations;

/// <summary>
/// Конфигурация для сущности студента в БД
/// </summary>
internal sealed class StudentEntityConfiguration : IEntityTypeConfiguration<StudentEntity> {
  /// <inheritdoc />
  public void Configure(EntityTypeBuilder<StudentEntity> builder) {
    builder.ToTable(Tables.Students);

    builder.HasKey(model => model.Id);

    builder.Property(model => model.Id)
      .HasColumnName("id")
      .ValueGeneratedOnAdd();

    builder.Property(model => model.AvatarUrl)
      .IsRequired(false)
      .HasColumnName("avatar_url")
      .HasMaxLength(AvatarUrlMaxLength);

    builder.Property(model => model.Email)
      .IsRequired()
      .HasColumnName("email")
      .HasMaxLength(EmailMaxLength);

    builder.Property(model => model.Name)
      .IsRequired()
      .HasColumnName("name")
      .HasMaxLength(NameMaxLength);
    
    builder.Property(model => model.RegistrationDate)
      .IsRequired()
      .HasColumnName("registration_date")
      .HasDefaultValueSql("timezone('utc', now())")
      .HasColumnType("timestamp without time zone");;
  }
}
