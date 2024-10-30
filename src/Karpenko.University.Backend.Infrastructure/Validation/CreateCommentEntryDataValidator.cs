using Karpenko.University.Backend.Application.Validation;
using Karpenko.University.Backend.Domain.CourseComment;
using CreateComment = Karpenko.University.Backend.Application.UseCases.CreateComment;

namespace Karpenko.University.Backend.Infrastructure.Validation;

/// <summary>
/// Валидатор данных для создания комментария
/// </summary>
internal sealed class CreateCommentEntryDataValidator : AbstractValidator<CreateComment.EntryData> {
  /// <inheritdoc />
  protected override void ValidateModel(CreateComment.EntryData model) {
    NumberValidator(nameof(model.CourseId), model.CourseId.GetValueOrDefault())
      .NotNull()
      .NotEmpty();
    
    NumberValidator(nameof(model.CreatorId), model.CreatorId.GetValueOrDefault())
      .NotNull()
      .NotEmpty();

    StringValidator(nameof(model.Content), model.Content)
      .NotEmpty();
      // Допустим можно строку любой длинны =)
      
    NumberValidator(nameof(model.Quality), (byte)model.Quality.GetValueOrDefault())
      .IsDefinedIn<CourseQuality>();
  }
}
