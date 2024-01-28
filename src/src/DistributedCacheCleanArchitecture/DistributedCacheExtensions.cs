using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DistributedCacheCleanArchitecture;

public static class DistributedCacheExtensions
{
    public static IServiceCollection AddDistributedCache(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IDistributedCleanArchitectureCache, DistributedCleanArchitectureCache>();
        services.AddDistributedMemoryCache();
        return services;
    }
}
