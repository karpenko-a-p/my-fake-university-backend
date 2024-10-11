using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Karpenko.University.Backend.Persistence.Database.Entities.CourseBindCourseTag;

/// <summary>
/// Конфигурация для связи курсов и тэгов к курсам в БД
/// </summary>
internal sealed class CourseBindCourseTagEntityConfiguration : IEntityTypeConfiguration<CourseBindCourseTagEntity> {
  /// <inheritdoc />
  public void Configure(EntityTypeBuilder<CourseBindCourseTagEntity> builder) {
    builder.ToTable(Tables.CourseBindTags);
    
    builder.HasKey(model => new { model.CourseId, model.CourseTagId });
    
    builder.Property(model => model.CourseId)
      .HasColumnName("course_id")
      .IsRequired();
    
    builder.Property(model => model.CourseTagId)
      .HasColumnName("tag_id")
      .IsRequired();

    builder
      .HasOne(model => model.Course)
      .WithMany(model => model.TagsBindings)
      .HasForeignKey(model => model.CourseId)
      .OnDelete(DeleteBehavior.Cascade)
      .HasConstraintName("fk_courses_tags_bind_course");

    builder
      .HasOne(model => model.Tag)
      .WithMany(model => model.CoursesBindings)
      .HasForeignKey(model => model.CourseTagId)
      .OnDelete(DeleteBehavior.Cascade)
      .HasConstraintName("fk_courses_tags_bind_tag");
  }
}
