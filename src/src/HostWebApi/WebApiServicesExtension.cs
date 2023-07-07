using Application.Core;
using Infraestructure.DataAccess;
using Microsoft.AspNetCore.DataProtection;

namespace Api
{
    public static class WebApiServicesExtension
    {
        public static IServiceCollection InicializarConfiguracionApp(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(WebApiServicesExtension), typeof(BusinessExtensions), typeof(AccessDataExtensions));
            services.AddOptions();
            services.AddCache(configuration);
            services.ConfigureDataProtectionProvider(configuration);


            services.AddBusinessServices();
            services.AddDataAccessService(configuration);

            return services;
        }

        public static IServiceCollection AddCache(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDistributedMemoryCache();
            return services;
        }

        public static IServiceCollection ConfigureDataProtectionProvider(this IServiceCollection services, IConfiguration configuration)
        {
            var keysFolder = configuration["keysFolder"]!;
            services.AddDataProtection()
                .PersistKeysToFileSystem(new DirectoryInfo(keysFolder))
                .SetApplicationName("Aplicacion.WebApi");
            return services;
        }
    }
}
