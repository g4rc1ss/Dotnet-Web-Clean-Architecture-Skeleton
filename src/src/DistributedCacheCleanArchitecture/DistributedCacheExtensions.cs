using Microsoft.Extensions.DependencyInjection;

namespace DistributedCacheCleanArchitecture;

public static class DistributedCacheExtensions
{
    public static IServiceCollection AddDistributedCache(this IServiceCollection services)
    {
        services.AddScoped<IDistributedCleanArchitectureCache, DistributedCleanArchitectureCache>();
        services.AddDistributedMemoryCache();
        return services;
    }
}
