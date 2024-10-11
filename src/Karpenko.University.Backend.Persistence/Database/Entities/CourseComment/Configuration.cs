using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Karpenko.University.Backend.Persistence.Database.Entities.CourseComment;

/// <summary>
/// Конфигурация сущности коммента к курсу в БД
/// </summary>
internal sealed class Configuration : IEntityTypeConfiguration<CourseCommentEntity> {
  /// <inheritdoc />
  public void Configure(EntityTypeBuilder<CourseCommentEntity> builder) {
    builder.ToTable(Tables.CoursesComments);

    builder.HasKey(model => model.Id);

    builder.Property(model => model.Id)
      .HasColumnName("id")
      .IsRequired()
      .ValueGeneratedOnAdd();

    builder.Property(model => model.AuthorId)
      .HasColumnName("author_id")
      .IsRequired(false);
    
    builder.Property(model => model.CourseId)
      .HasColumnName("course_id")
      .IsRequired(false);

    builder.Property(model => model.Content)
      .HasColumnName("content")
      .HasColumnType("text")
      .IsRequired();

    builder.Property(model => model.Quality)
      .HasColumnName("quality")
      .HasConversion<string>()
      .IsRequired();

    builder.Property(model => model.CreationDate)
      .HasColumnName("creation_date")
      .HasDefaultValueSql("timezone('utc', now())")
      .HasColumnType("timestamp without time zone")
      .IsRequired();

    builder
      .HasOne(model => model.Author)
      .WithMany(model => model.CoursesComments)
      .HasForeignKey(model => model.AuthorId)
      .OnDelete(DeleteBehavior.SetNull)
      .HasConstraintName("fk_course_comments_author");
    
    builder
      .HasOne(model => model.Course)
      .WithMany(model => model.Comments)
      .HasForeignKey(model => model.CourseId)
      .OnDelete(DeleteBehavior.SetNull)
      .HasConstraintName("fk_course_comments_course");
  }
}

