using Karpenko.University.Backend.Domain.Student;

namespace Karpenko.University.Backend.Application.UseCases.CreateStudent;

public interface IStudentRepository {
  Task<bool> CheckStudentExistsByEmailAsync(string email, CancellationToken cancellationToken);
  Task<StudentModel> CreateStudentAsync(CreateStudentDto student, CancellationToken cancellationToken);
}
