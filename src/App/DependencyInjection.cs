﻿namespace App
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
	}
}
