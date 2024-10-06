namespace Karpenko.University.Backend.Application.UseCases.GetStudentById;

/// <summary>
/// Данные для поиска студента по идентификатору
/// </summary>
/// <param name="Id">Идентификатор</param>
public sealed record EntryData(long? Id);
