using CreateStudent = Karpenko.University.Backend.Application.UseCases.CreateStudent;
using GetStudentByExpression = Karpenko.University.Backend.Application.UseCases.GetStudentByExpression;
using VerifyStudentPassword = Karpenko.University.Backend.Application.UseCases.VerifyStudentPassword;
using Karpenko.University.Backend.Domain.Student;
using Karpenko.University.Backend.Persistence.Database.Contexts;
using Karpenko.University.Backend.Persistence.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Karpenko.University.Backend.Persistence.Repositories;

/// <summary>
/// Репозиторий для работы с данными студентов
/// </summary>
internal sealed class StudentRepository(PostgresDbContext db) : AbstractRepository<PostgresDbContext>(db),
  CreateStudent.IStudentRepository,
  GetStudentByExpression.IStudentRepository,
  VerifyStudentPassword.IStudentRepository
{
  /// <inheritdoc />
  public Task<bool> CheckStudentExistsByEmailAsync(string email, CancellationToken cancellationToken) {
    return db.Students.AnyAsync(student => student.Email == email, cancellationToken);
  }

  /// <inheritdoc />
  public async Task<StudentModel> CreateStudentAsync(CreateStudent.CreateStudentDto createStudentDto, CancellationToken cancellationToken) {
    var studentEntity = new StudentEntity {
      Email = createStudentDto.Email,
      Name = createStudentDto.Name,
    };

    await db.Students.AddAsync(studentEntity, cancellationToken);
    await db.SaveChangesAsync(cancellationToken);

    return new() {
      Id = studentEntity.Id,
      AvatarUrl = studentEntity.AvatarUrl ?? string.Empty,
      RegistrationDate = studentEntity.RegistrationDate,
      Name = studentEntity.Name,
      Email = studentEntity.Email,
    };
  }

  /// <inheritdoc />
  public async Task SaveStudentPasswordAsync(ulong studentId, string password, CancellationToken cancellationToken) {
    await db.StudentsPasswords.AddAsync(new() { StudentId = studentId, Password = password }, cancellationToken);
    await db.SaveChangesAsync(cancellationToken);
  }

  /// <inheritdoc />
  public async Task<StudentModel?> GetStudentByExpressionAsync(Func<GetStudentByExpression.IStudentSearchable, bool> expression, CancellationToken cancellationToken) {
    // TODO заглушка
    var candidate = Enumerable.Empty<GetStudentByExpression.IStudentSearchable>().FirstOrDefault(expression);

    if (candidate is null) return null;

    return new();
  }

  /// <inheritdoc />
  public async Task<string?> GetStudentPasswordByIdAsync(ulong id, CancellationToken cancellationToken) {
    var studentPasswordEntity = await db.StudentsPasswords
      .AsNoTracking()
      .FirstOrDefaultAsync(model => model.StudentId == id, cancellationToken);

    return studentPasswordEntity?.Password;
  }
}
