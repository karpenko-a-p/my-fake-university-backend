using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Karpenko.University.Backend.Domain.CourseStep.CourseStepModel;

namespace Karpenko.University.Backend.Persistence.Database.Entities.CourseStep;

/// <summary>
/// Конфигурация дял сущности шага курса в БД
/// </summary>
internal sealed class CourseStepEntityConfiguration : IEntityTypeConfiguration<CourseStepEntity> {
  /// <inheritdoc />
  public void Configure(EntityTypeBuilder<CourseStepEntity> builder) {
    builder.ToTable(Tables.CoursesSteps);

    builder.HasKey(model => model.Id);

    builder.Property(model => model.Id)
      .HasColumnName("id")
      .IsRequired()
      .ValueGeneratedOnAdd();

    builder.Property(model => model.Name)
      .HasColumnName("name")
      .HasMaxLength(NameMaxLength)
      .IsRequired();
    
    builder.Property(model => model.Description)
      .HasColumnName("description")
      .HasColumnType("text")
      .IsRequired();

    builder.Property(model => model.PassageTime)
      .HasColumnName("passage_time")
      .IsRequired();

    builder.Property(model => model.PositionIndex)
      .HasColumnName("position_index")
      .IsRequired();

    builder.Property(model => model.CourseId)
      .HasColumnName("course_id")
      .IsRequired();
    
    builder
      .HasOne(model => model.Course)
      .WithMany(model => model.Steps)
      .HasForeignKey(model => model.CourseId)
      .OnDelete(DeleteBehavior.Cascade)
      .HasConstraintName("fk_course_steps");
  }
}
