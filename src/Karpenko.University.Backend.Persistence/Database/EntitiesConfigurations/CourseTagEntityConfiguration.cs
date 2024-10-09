using Karpenko.University.Backend.Persistence.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Karpenko.University.Backend.Domain.CourseTag.CourseTagModel;

namespace Karpenko.University.Backend.Persistence.Database.EntitiesConfigurations;

/// <summary>
/// Конфигурация для сущности тэга курса
/// </summary>
internal sealed class CourseTagEntityConfiguration : IEntityTypeConfiguration<CourseTagEntity> {
  /// <inheritdoc />
  public void Configure(EntityTypeBuilder<CourseTagEntity> builder) {
    builder.ToTable(Tables.CoursesTags);

    builder.HasKey(model => model.Id);

    builder.Property(model => model.Id)
      .HasColumnName("id")
      .IsRequired();

    builder.Property(model => model.Name)
      .HasColumnName("name")
      .HasMaxLength(NameMaxLength)
      .IsRequired();
  }
}
