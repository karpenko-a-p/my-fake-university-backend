using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Karpenko.University.Backend.Persistence.Database.Entities.CourseContent;

/// <summary>
/// Конфигурация сущности содержимого курса 
/// </summary>
internal sealed class Configuration : IEntityTypeConfiguration<CourseContentEntity> {
  /// <inheritdoc />
  public void Configure(EntityTypeBuilder<CourseContentEntity> builder) {
    builder.ToTable(Tables.Content);
    
    builder.HasKey(model => model.Id);

    builder.Property(model => model.Id)
      .HasColumnName("id")
      .ValueGeneratedOnAdd()
      .IsRequired();

    builder.Property(model => model.CourseId)
      .HasColumnName("course_id")
      .IsRequired();

    builder.Property(model => model.VideoFileName)
      .HasColumnName("video_filename")
      .HasColumnType("text")
      .IsRequired();

    builder
      .HasOne(model => model.Course)
      .WithOne(model => model.CourseContent)
      .HasForeignKey<CourseContentEntity>(model => model.CourseId)
      .OnDelete(DeleteBehavior.Restrict)
      .HasConstraintName("fk_course_content");
  }
}
