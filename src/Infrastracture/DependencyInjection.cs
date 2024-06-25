using DocumentArchive.Domain.CategoryAggregator;
using DocumentArchive.Domain.CommentAggregator;
using DocumentArchive.Domain.CustomerAggregator;
using DocumentArchive.Domain.DocumentAggregator;
using DocumentArchive.Infrastructure.Persistence;
using DocumentArchive.Infrastructure.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DocumentArchive.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureInfrastructureLayer(this IServiceCollection services,
         IConfiguration configuration)
    {


        var application = typeof(IAssemblyMarker);


        services.AddDbContext<DocumentArchiveDbContext>(options => {
            options.UseSqlServer(configuration.GetConnectionString(DocumentArchiveDbContextSchema.DefaultConnectionStringName));
        });

        services.AddScoped<IDocumentRepository, DocumentRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();

        return services;

    }
}
