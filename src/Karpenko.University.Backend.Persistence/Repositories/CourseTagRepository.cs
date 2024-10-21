using Karpenko.University.Backend.Domain.CourseTag;
using Karpenko.University.Backend.Persistence.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using GetCoursesTags = Karpenko.University.Backend.Application.UseCases.GetCoursesTags;
using GetTagsByCourseId = Karpenko.University.Backend.Application.UseCases.GetTagsByCourseId;

namespace Karpenko.University.Backend.Persistence.Repositories;

/// <summary>
/// Репозиторий для работы с тэгами курсов
/// </summary>
internal sealed class CourseTagRepository(PostgresDbContext db) : AbstractRepository<PostgresDbContext>(db), 
  GetCoursesTags.ITagRepository,
  GetTagsByCourseId.ITagRepository
{
  /// <inheritdoc />
  public async Task<ICollection<CourseTagModel>> GetCoursesTagsAsync(CancellationToken cancellationToken) {
    return await db.Tags
      .AsNoTracking()
      .Select(tagEntity => new CourseTagModel {
        Id = tagEntity.Id,
        Name = tagEntity.Name
      })
      .ToListAsync(cancellationToken);
  }

  /// <inheritdoc />
  public async Task<ICollection<CourseTagModel>> GetTagsByCourseIdAsync(long courseId, CancellationToken cancellationToken) {
    return await db.Tags
      .AsNoTracking()
      .Include(tag => tag.CoursesBindings)
      .AsSplitQuery()
      .Where(tag => tag.CoursesBindings.Any(binding => binding.CourseId == courseId))
      .Select(tag => new CourseTagModel {
        Id = tag.Id,
        Name = tag.Name
      })
      .ToListAsync(cancellationToken);
  }
}
