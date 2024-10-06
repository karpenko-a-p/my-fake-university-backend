namespace Karpenko.University.Backend.Application.UseCases.DeleteStudentById;

/// <summary>
/// Данные для удаления данных студента
/// </summary>
/// <param name="StudentId">Идентификатор студента</param>
public sealed record EntryData(ulong StudentId);
