using Karpenko.University.Backend.Domain.CourseTag;
using Karpenko.University.Backend.Persistence.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using GetCoursesTags = Karpenko.University.Backend.Application.UseCases.GetCoursesTags;

namespace Karpenko.University.Backend.Persistence.Repositories;

/// <summary>
/// Репозиторий для работы с тэгами курсов
/// </summary>
internal sealed class CourseTagRepository(PostgresDbContext db) : AbstractRepository<PostgresDbContext>(db), 
  GetCoursesTags.ITagRepository
{
  /// <inheritdoc />
  public async Task<ICollection<CourseTagModel>> GetCoursesTagsAsync(CancellationToken cancellationToken) {
    return await db.Tags
      .Select(tagEntity => new CourseTagModel {
        Id = tagEntity.Id,
        Name = tagEntity.Name
      })
      .ToListAsync(cancellationToken);
  }
}
