namespace App.Database
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependecyInjection
    {
        public static IServiceCollection LoadDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                var useInMemoryDatabase = configuration.GetValue<bool?>("UseInMemoryDatabase");
                
                if (useInMemoryDatabase.Value == true)
                {
                    options.UseInMemoryDatabase(nameof(AppDbContext));
                }
                else
                {
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                }
            });

            services.AddScoped<IAppDbContext>(
                serviceProvider => serviceProvider.GetRequiredService<AppDbContext>());

            return services;
        }
    }
}