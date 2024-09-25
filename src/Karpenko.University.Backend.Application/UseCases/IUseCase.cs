using Karpenko.University.Backend.Core.CommandPattern;
using Karpenko.University.Backend.Core.ResultPattern;

namespace Karpenko.University.Backend.Application.UseCases;

/// <summary>
/// Интерфейс выполняемого сценария использования
/// </summary>
public interface IUseCase : ICommand<IResult>;
