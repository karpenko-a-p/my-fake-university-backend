using Karpenko.University.Backend.Core.CommandPattern;
using Karpenko.University.Backend.Core.ResultPattern;

namespace Karpenko.University.Backend.Application.UseCases;

/// <summary>
/// Интерфейс асинхронно выполняемого сценария использования
/// </summary>
public interface IAsyncUseCase : IAsyncCommand<IResult>;
