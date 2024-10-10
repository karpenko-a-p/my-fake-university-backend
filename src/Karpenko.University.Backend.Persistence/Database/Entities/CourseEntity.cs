namespace Karpenko.University.Backend.Persistence.Database.Entities;

/// <summary>
/// Сущность курса в БД
/// </summary>
internal sealed class CourseEntity {
  /// <summary>
  /// Идентификатор
  /// </summary>
  public long Id { get; set; }

  /// <summary>
  /// Название
  /// </summary>
  public string Name { get; set; } = string.Empty;

  /// <summary>
  /// Описание
  /// </summary>
  public string Description { get; set; } = string.Empty;

  /// <summary>
  /// Лого курса
  /// </summary>
  public string? LogoUrl { get; set; }
  
  /// <summary>
  /// Дата создания
  /// </summary>
  public DateTime CreationDate { get; set; }
  
  /// <summary>
  /// Кол-во людей купивших курс
  /// </summary>
  public long BoughtCount { get; set; }

  /// <summary>
  /// Идентификатор стоимости для курса
  /// </summary>
  public long PriceId { get; set; }
  
  /// <summary>
  /// Навигация на стоимость курса
  /// </summary>
  public PriceEntity? Price { get; set; }

  /// <summary>
  /// Навигация на тэги курса
  /// </summary>
  public ICollection<CourseTagEntity> Tags { get; set; } = [];
  
  /// <summary>
  /// Навигация на соединение c тэгами
  /// </summary>
  public ICollection<CourseBindCourseTagEntity> TagsBindings { get; set; } = [];

  /// <summary>
  /// Навигация на комментарии к курсу
  /// </summary>
  public ICollection<CourseCommentEntity> Comments { get; set; } = [];

  /// <summary>
  /// Навигация на этапы/шаги курса
  /// </summary>
  public ICollection<CourseStepEntity> Steps { get; set; } = [];
}
