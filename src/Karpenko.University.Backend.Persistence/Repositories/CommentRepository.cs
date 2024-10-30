using Karpenko.University.Backend.Domain.CourseComment;
using Karpenko.University.Backend.Persistence.Database.Contexts;
using Karpenko.University.Backend.Persistence.Database.Entities.CourseComment;
using Microsoft.EntityFrameworkCore;
using CreateComment = Karpenko.University.Backend.Application.UseCases.CreateComment;
using DeleteCommentById = Karpenko.University.Backend.Application.UseCases.DeleteCommentById;

namespace Karpenko.University.Backend.Persistence.Repositories;

/// <summary>
/// Репозиторий для работы с комментариями
/// </summary>
internal sealed class CommentRepository(PostgresDbContext db) : AbstractRepository<PostgresDbContext>(db),
  CreateComment.ICommentRepository,
  DeleteCommentById.ICommentRepository
{
  /// <inheritdoc />
  public async Task<CourseCommentModel> CreateCommentAsync(CreateComment.CreateCommentDto createCommentDto, CancellationToken cancellationToken) {
    var commentEntity = new CourseCommentEntity {
      AuthorId = createCommentDto.StudentId,
      CourseId = createCommentDto.CourseId,
      Content = createCommentDto.Content,
      Quality = createCommentDto.Quality
    };
    
    await db.Comments.AddAsync(commentEntity, cancellationToken);
    await db.SaveChangesAsync(cancellationToken);
    
    return commentEntity.ToCourseCommentModel();
  }

  /// <inheritdoc />
  public async Task<CourseCommentModel?> GetCommentByIdAsync(long id, CancellationToken cancellationToken) {
    var comment = await db.Comments
      .AsNoTracking()
      .FirstOrDefaultAsync(comment => comment.Id == id, cancellationToken);

    return comment?.ToCourseCommentModel();
  }

  /// <inheritdoc />
  public async Task DeleteCourseByIdAsync(long id, CancellationToken cancellationToken) {
    await db.Comments
      .Where(comment => comment.Id == id)
      .ExecuteDeleteAsync(cancellationToken);
  }
}
