using CreateStudent = Karpenko.University.Backend.Application.UseCases.CreateStudent;
using VerifyStudentPassword = Karpenko.University.Backend.Application.UseCases.VerifyStudentPassword;
using GetStudentByEmail = Karpenko.University.Backend.Application.UseCases.GetStudentByEmail;
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
  VerifyStudentPassword.IStudentRepository,
  GetStudentByEmail.IStudentRepository
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

    return studentEntity.ToStudentModel();
  }

  /// <inheritdoc />
  public async Task SaveStudentPasswordAsync(ulong studentId, string password, CancellationToken cancellationToken) {
    await db.StudentsPasswords.AddAsync(new() { StudentId = studentId, Password = password }, cancellationToken);
    await db.SaveChangesAsync(cancellationToken);
  }

  /// <inheritdoc />
  public async Task<string?> GetStudentPasswordByIdAsync(ulong id, CancellationToken cancellationToken) {
    var studentPasswordEntity = await db.StudentsPasswords
      .AsNoTracking()
      .FirstOrDefaultAsync(model => model.StudentId == id, cancellationToken);

    return studentPasswordEntity?.Password;
  }

  /// <inheritdoc />
  public async Task<StudentModel?> GetStudentByEmailAsync(string email, CancellationToken cancellationToken) {
    var studentEntity = await db.Students
      .AsNoTracking()
      .FirstOrDefaultAsync(student => student.Email == email, cancellationToken);

    if (studentEntity is null)
      return null;
    
    return studentEntity.ToStudentModel();
  }
}
