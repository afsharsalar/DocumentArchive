

using DocumentArchive.APIs.Endpoints.Auth;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using System.Text;

namespace DocumentArchive.APIs
{
    public static class DependencyInjection
    {
        private readonly static Assembly[] Assemblies = AppDomain.CurrentDomain.GetAssemblies();
        public static IServiceCollection ConfigureMapster(this IServiceCollection services)
        {
            var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
            typeAdapterConfig.Scan(Assemblies);

            services.AddSingleton(typeAdapterConfig);
            services.AddScoped<IMapper, ServiceMapper>();

            return services;
        }

        public static IServiceCollection ConfigureValidator(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblies(Assemblies);

            return services;
        }


        public static IServiceCollection ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowOrigin",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            return services;
        }


        public static IServiceCollection AddEndpoints(this IServiceCollection services)
        {
            var assembly = typeof(IAssemblyMarker).Assembly;

            ServiceDescriptor[] serviceDescriptors = assembly
                .DefinedTypes
                .Where(type => type is { IsAbstract: false, IsInterface: false } &&
                               type.IsAssignableTo(typeof(IEndpoint)))
                .Select(type => ServiceDescriptor.Transient(typeof(IEndpoint), type))
                .ToArray();

            services.TryAddEnumerable(serviceDescriptors);

            return services;
        }

        public static IApplicationBuilder MapEndpoints(this WebApplication app)
        {
            IEnumerable<IEndpoint> endpoints = app.Services
                                                  .GetRequiredService<IEnumerable<IEndpoint>>();

            foreach (IEndpoint endpoint in endpoints)
            {
                endpoint.MapEndpoint(app);
            }

            return app;
        }


        public static IServiceCollection AddJWT(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSetting>(configuration.GetSection("Jwt"));


            var jwtSettings = new JwtSetting();
            configuration.GetSection("Jwt").Bind(jwtSettings);
            var key = Encoding.ASCII.GetBytes(jwtSettings.Key);


            

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
              {
                  x.RequireHttpsMetadata = false;
                  x.SaveToken = true;
                  x.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuerSigningKey = true,
                      IssuerSigningKey = new SymmetricSecurityKey(key),
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidIssuer = jwtSettings.Issuer,
                      ValidAudience = jwtSettings.Audience,
                      ValidateLifetime = true,
                      ClockSkew = TimeSpan.Zero
                  };
              });
            return services;
      
        }
    }



}