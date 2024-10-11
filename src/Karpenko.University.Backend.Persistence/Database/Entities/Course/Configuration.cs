using Karpenko.University.Backend.Persistence.Database.Entities.CourseBindCourseTag;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Karpenko.University.Backend.Domain.Course.CourseModel;

namespace Karpenko.University.Backend.Persistence.Database.Entities.Course;

/// <summary>
/// Конфигурация для сущности курса в БД
/// </summary>
internal sealed class Configuration : IEntityTypeConfiguration<CourseEntity> {
  /// <inheritdoc />
  public void Configure(EntityTypeBuilder<CourseEntity> builder) {
    builder.ToTable(Tables.Courses);
    
    builder.HasKey(model => model.Id);
    
    builder.Property(model => model.Id)
      .HasColumnName("id")
      .IsRequired()
      .ValueGeneratedOnAdd();
    
    builder.Property(model => model.PriceId)
      .HasColumnName("price_id")
      .IsRequired();

    builder.Property(model => model.Name)
      .IsRequired()
      .HasColumnName("name")
      .HasMaxLength(NameMaxLength);

    builder.Property(model => model.Description)
      .IsRequired()
      .HasColumnName("description");

    builder.Property(model => model.LogoUrl)
      .HasColumnName("logo_url")
      .IsRequired(false);

    builder.Property(model => model.CreationDate)
      .IsRequired()
      .HasColumnName("creation_date")
      .HasDefaultValueSql("timezone('utc', now())")
      .HasColumnType("timestamp without time zone");

    builder.Property(model => model.BoughtCount)
      .IsRequired()
      .HasColumnName("bought_count");

    builder
      .HasOne(model => model.Price)
      .WithOne(model => model.Course)
      .HasForeignKey<CourseEntity>(model => model.PriceId)
      .OnDelete(DeleteBehavior.Cascade)
      .HasConstraintName("fk_course_price");

    builder
      .HasMany(model => model.Tags)
      .WithMany(model => model.Courses)
      .UsingEntity<CourseBindCourseTagEntity>();

    builder
      .HasMany(model => model.Comments)
      .WithOne(model => model.Course)
      .HasForeignKey(model => model.CourseId);
  }
}

