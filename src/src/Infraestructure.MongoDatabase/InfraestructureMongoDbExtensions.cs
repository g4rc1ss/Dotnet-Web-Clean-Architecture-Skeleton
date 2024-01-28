using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using MongoDB.Driver.Core.Extensions.DiagnosticSources;

namespace Infraestructure.MongoDatabase;

public static class InfraestructureMongoDbExtensions
{

    public static IServiceCollection AddMongoDbConfig(this IServiceCollection services, IConfiguration configuration)
    {
        var host = configuration.GetConnectionString("CleanArchitectureSkeletonMongoDb");
        var clientSettings = MongoClientSettings.FromConnectionString(host);
        clientSettings.ClusterConfigurator = cb => cb.Subscribe(new DiagnosticsActivityEventSubscriber());
        services.AddScoped(provider => new MongoClient(clientSettings));

        return services;
    }
}

