using Karpenko.University.Backend.Application.Pagination;
using Karpenko.University.Backend.Domain.Course;
using Karpenko.University.Backend.Persistence.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using GetCourses = Karpenko.University.Backend.Application.UseCases.GetCourses;

namespace Karpenko.University.Backend.Persistence.Repositories;

/// <summary>
/// Репозиторий для работы с курсами
/// </summary>
internal sealed class CourseRepository(PostgresDbContext db) : AbstractRepository<PostgresDbContext>(db),
  GetCourses.ICourseRepository
{
  /// <inheritdoc />
  public async Task<ICollection<CourseModel>> GetCoursesAsync(PaginationModel pagination, CancellationToken cancellationToken) {
    return await db.Courses
      .Paginate(pagination)
      .Select(courseEntity => courseEntity.ToCourseModel())
      .ToListAsync(cancellationToken);
  }

  /// <inheritdoc />
  public Task<int> GetCoursesCountAsync(CancellationToken cancellationToken) {
    return db.Courses.CountAsync(cancellationToken);
  }
}
