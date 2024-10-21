using Karpenko.University.Backend.Application.Pagination;
using Karpenko.University.Backend.Domain.Course;
using Karpenko.University.Backend.Persistence.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using GetCourses = Karpenko.University.Backend.Application.UseCases.GetCourses;
using GetCourseById = Karpenko.University.Backend.Application.UseCases.GetCourseById;

namespace Karpenko.University.Backend.Persistence.Repositories;

/// <summary>
/// Репозиторий для работы с курсами
/// </summary>
internal sealed class CourseRepository(PostgresDbContext db) : AbstractRepository<PostgresDbContext>(db),
  GetCourses.ICourseRepository,
  GetCourseById.ICourseRepository
{
  /// <inheritdoc />
  public async Task<ICollection<CourseModel>> GetCoursesAsync(PaginationModel pagination, CancellationToken cancellationToken) {
    return await db.Courses
      .AsNoTracking()
      .Paginate(pagination)
      .Select(courseEntity => courseEntity.ToCourseModel())
      .ToListAsync(cancellationToken);
  }

  /// <inheritdoc />
  public Task<int> GetCoursesCountAsync(CancellationToken cancellationToken) {
    return db.Courses.CountAsync(cancellationToken);
  }

  /// <inheritdoc />
  public async Task<CourseModel?> GetCourseByIdAsync(long id, CancellationToken cancellationToken) {
    var courseEntity = await db.Courses
      .AsNoTracking()
      .FirstOrDefaultAsync(model => model.Id == id, cancellationToken);

    return courseEntity?.ToCourseModel();
  }
}
