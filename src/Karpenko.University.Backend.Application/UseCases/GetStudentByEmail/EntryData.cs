namespace Karpenko.University.Backend.Application.UseCases.GetStudentByEmail;

/// <summary>
/// Данные для поиска студента по почте
/// </summary>
/// <param name="Email">Почта</param>
public sealed record EntryData(string? Email);
