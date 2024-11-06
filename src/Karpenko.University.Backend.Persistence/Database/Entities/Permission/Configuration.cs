using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Karpenko.University.Backend.Persistence.Database.Entities.Permission;

/// <summary>
/// Конфигурация для сущности прав доступа
/// </summary>
internal sealed class Configuration : IEntityTypeConfiguration<PermissionEntity> {
  /// <inheritdoc />
  public void Configure(EntityTypeBuilder<PermissionEntity> builder) {
    builder.ToTable(Tables.Permissions);

    builder.HasKey(model => new {
      model.OwnerId,
      model.SubjectId,
      model.PermissionType,
      model.PermissionSubject
    });

    builder.Property(model => model.OwnerId)
      .HasColumnName("owner_id")
      .IsRequired();

    builder.Property(model => model.SubjectId)
      .HasColumnName("subject_id")
      .IsRequired();

    builder.Property(model => model.PermissionSubject)
      .HasColumnName("permission_subject")
      .IsRequired()
      .HasConversion<string>();

    builder.Property(model => model.PermissionType)
      .HasColumnName("permission_type")
      .IsRequired()
      .HasConversion<string>();
  }
}
