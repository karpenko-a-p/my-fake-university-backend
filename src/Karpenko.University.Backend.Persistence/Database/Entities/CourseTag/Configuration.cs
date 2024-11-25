﻿using Karpenko.University.Backend.Persistence.Database.Entities.CourseBindCourseTag;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Karpenko.University.Backend.Domain.CourseTag.CourseTagModel;

namespace Karpenko.University.Backend.Persistence.Database.Entities.CourseTag;

/// <summary>
/// Конфигурация для сущности тэга курса
/// </summary>
internal sealed class Configuration : IEntityTypeConfiguration<CourseTagEntity> {
  /// <inheritdoc />
  public void Configure(EntityTypeBuilder<CourseTagEntity> builder) {
    builder.ToTable(Tables.CoursesTags);

    builder.HasKey(model => model.Id);

    builder.Property(model => model.Id)
      .HasColumnName("id")
      .IsRequired()
      .ValueGeneratedOnAdd();

    builder.Property(model => model.Name)
      .HasColumnName("name")
      .HasMaxLength(NameMaxLength)
      .IsRequired();

    builder
      .HasMany(model => model.Courses)
      .WithMany(model => model.Tags)
      .UsingEntity<CourseBindCourseTagEntity>();
  }
}
