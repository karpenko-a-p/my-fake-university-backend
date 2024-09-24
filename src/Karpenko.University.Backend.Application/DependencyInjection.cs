using Microsoft.Extensions.DependencyInjection;

namespace Karpenko.University.Backend.Application;

public static class DependencyInjection {
  public static IServiceCollection AddApplication(this IServiceCollection services) {
    return services;
  }
}
