namespace Karpenko.University.Backend.Application.UseCases.GetCourseVideo;

/// <summary>
/// Параметры для конфигурации видео
/// </summary>
public sealed class VideoContentOptions {
  /// <summary>
  /// Путь к видео с контентом курсов
  /// </summary>
  public string Path { get; set; } = string.Empty;
}
