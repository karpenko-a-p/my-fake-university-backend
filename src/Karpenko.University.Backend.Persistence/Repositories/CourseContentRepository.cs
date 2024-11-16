using Karpenko.University.Backend.Domain.CourseContent;
using Karpenko.University.Backend.Persistence.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using GetCourseVideo = Karpenko.University.Backend.Application.UseCases.GetCourseVideo;

namespace Karpenko.University.Backend.Persistence.Repositories;

/// <summary>
/// Репозиторий для работы с контентом курсов (видео)
/// </summary>
internal sealed class CourseContentRepository(PostgresDbContext db) : AbstractRepository<PostgresDbContext>(db),
  GetCourseVideo.ICourseContentRepository
{
  /// <inheritdoc />
  public async Task<CourseContentModel?> GetCourseContentCourseIdAsync(long courseId, CancellationToken cancellationToken) {
    var courseContent = await db.Content
      .AsNoTracking()
      .FirstOrDefaultAsync(model => model.CourseId == courseId, cancellationToken);

    return courseContent?.ToCourseContentModel();
  }
}
