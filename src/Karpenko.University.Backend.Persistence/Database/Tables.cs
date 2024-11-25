﻿namespace Karpenko.University.Backend.Persistence.Database;

/// <summary>
/// Таблицы БД
/// </summary>
internal static class Tables {
  /// <summary>
  /// Миграции БД
  /// </summary>
  public const string MigrationsHistory = "migrations_history";
  
  /// <summary>
  /// Таблица со студентами
  /// </summary>
  public const string Students = "students_data";
  
  /// <summary>
  /// Таблица с паролями студентов
  /// </summary>
  public const string StudentsPasswords = "students_passwords";
  
  /// <summary>
  /// Таблица с правами доступа
  /// </summary>
  public const string Permissions = "permissions";

  /// <summary>
  /// Таблица с комментариями к курсам
  /// </summary>
  public const string CoursesComments = "courses_comments";
  
  /// <summary>
  /// Таблица с тэгами курсов
  /// </summary>
  public const string CoursesTags = "courses_tags";

  /// <summary>
  /// Таблица с данными курсов
  /// </summary>
  public const string Courses = "courses_data";

  /// <summary>
  /// Таблица связи курсов и тэгов
  /// </summary>
  public const string CourseBindTags = "courses_bind_tags";

  /// <summary>
  /// Таблица с данными заказов
  /// </summary>
  public const string Orders = "orders_data";

  /// <summary>
  /// Таблица с данными содержимого курсов
  /// </summary>
  public const string Content = "course_content";
}
