using System;
using SuperVet.Data;

namespace SuperVet
{
	public static class ServicesConfiguration
	{
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(config.GetConnectionString("SuperVet"));
            });

            services.AddScoped<IDataContext>(provider => provider.GetService<DataContext>());
            services.AddScoped<IPatientService, PatientService>();

            return services;
        }

        public static IServiceCollection AddProviders(this IServiceCollection services)
		{
			services.AddScoped<IPatientService, PatientService>();

			return services;
		}
    }
}

