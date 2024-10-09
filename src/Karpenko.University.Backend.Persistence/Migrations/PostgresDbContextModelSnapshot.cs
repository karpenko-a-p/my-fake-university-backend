﻿// <auto-generated />
using System;
using Karpenko.University.Backend.Persistence.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Karpenko.University.Backend.Persistence.Migrations
{
    [DbContext(typeof(PostgresDbContext))]
    partial class PostgresDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("university_backend")
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Karpenko.University.Backend.Persistence.Database.Entities.CourseCommentEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("AuthorId")
                        .IsRequired()
                        .HasColumnType("bigint")
                        .HasColumnName("author_id");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("creation_date")
                        .HasDefaultValueSql("timezone('utc', now())");

                    b.Property<string>("Quality")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("quality");

                    b.HasKey("Id")
                        .HasName("pk_courses_comments");

                    b.HasIndex("AuthorId")
                        .HasDatabaseName("ix_courses_comments_author_id");

                    b.ToTable("courses_comments", "university_backend");
                });

            modelBuilder.Entity("Karpenko.University.Backend.Persistence.Database.Entities.PermissionEntity", b =>
                {
                    b.Property<long>("OwnerId")
                        .HasColumnType("bigint")
                        .HasColumnName("owner_id");

                    b.Property<long>("SubjectId")
                        .HasColumnType("bigint")
                        .HasColumnName("subject_id");

                    b.Property<string>("PermissionType")
                        .HasColumnType("text")
                        .HasColumnName("permission_type");

                    b.HasKey("OwnerId", "SubjectId", "PermissionType")
                        .HasName("pk_permissions");

                    b.ToTable("permissions", "university_backend");
                });

            modelBuilder.Entity("Karpenko.University.Backend.Persistence.Database.Entities.StudentEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("AvatarUrl")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("avatar_url");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.Property<DateTime>("RegistrationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("registration_date")
                        .HasDefaultValueSql("timezone('utc', now())");

                    b.HasKey("Id")
                        .HasName("pk_students_data");

                    b.ToTable("students_data", "university_backend");
                });

            modelBuilder.Entity("Karpenko.University.Backend.Persistence.Database.Entities.StudentPasswordEntity", b =>
                {
                    b.Property<long>("StudentId")
                        .HasColumnType("bigint")
                        .HasColumnName("student_id");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.HasKey("StudentId")
                        .HasName("pk_students_passwords");

                    b.ToTable("students_passwords", "university_backend");
                });

            modelBuilder.Entity("Karpenko.University.Backend.Persistence.Database.Entities.CourseCommentEntity", b =>
                {
                    b.HasOne("Karpenko.University.Backend.Persistence.Database.Entities.StudentEntity", "Author")
                        .WithMany("CoursesComments")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired()
                        .HasConstraintName("fk_course_comments_author");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Karpenko.University.Backend.Persistence.Database.Entities.StudentPasswordEntity", b =>
                {
                    b.HasOne("Karpenko.University.Backend.Persistence.Database.Entities.StudentEntity", "Student")
                        .WithOne("Password")
                        .HasForeignKey("Karpenko.University.Backend.Persistence.Database.Entities.StudentPasswordEntity", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_student_password");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Karpenko.University.Backend.Persistence.Database.Entities.StudentEntity", b =>
                {
                    b.Navigation("CoursesComments");

                    b.Navigation("Password");
                });
#pragma warning restore 612, 618
        }
    }
}
