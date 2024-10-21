using Karpenko.University.Backend.Application.Caching;
using Karpenko.University.Backend.Domain.CourseTag;

namespace Karpenko.University.Backend.Application.UseCases.GetCoursesTags;

/// <summary>
/// Сервис для работы с кэшем тэгов курсов
/// </summary>
public interface ICacheService : IBaseCacheService<ICollection<CourseTagModel>>;
