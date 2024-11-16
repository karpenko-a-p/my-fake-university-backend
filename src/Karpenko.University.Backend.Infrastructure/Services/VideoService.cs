using Microsoft.Extensions.Options;
using GetCourseVideo = Karpenko.University.Backend.Application.UseCases.GetCourseVideo;

namespace Karpenko.University.Backend.Infrastructure.Services;

/// <summary>
/// Сервис для работы с видео
/// </summary>
internal sealed class VideoService(IOptions<GetCourseVideo.VideoContentOptions> videoOptions) : GetCourseVideo.IVideoService {
  /// <inheritdoc />
  public FileInfo GetVideoFile(string videoFileName) {
    return new FileInfo(Path.GetFullPath(videoOptions.Value.Path, videoFileName));
  }
}
