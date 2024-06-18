using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DocumentArchive.Application;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureApplicationLayer(this IServiceCollection services,
         IConfiguration configuration)
    {


        var application = typeof(IAssemblyMarker);
        services.AddMediatR(config => config.RegisterServicesFromAssembly(application.Assembly));

        return services;

    }
}
