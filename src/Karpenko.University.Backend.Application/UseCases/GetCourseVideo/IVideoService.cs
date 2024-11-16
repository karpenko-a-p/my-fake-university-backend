namespace Karpenko.University.Backend.Application.UseCases.GetCourseVideo;

/// <summary>
/// Сервис для работы с видео
/// </summary>
public interface IVideoService {
  /// <summary>
  /// Получение данных видео файла
  /// </summary>
  FileInfo GetVideoFile(string videoFileName);
}
