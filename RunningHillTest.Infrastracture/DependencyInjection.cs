using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RunningHillTest.Application.Interfaces;
using RunningHillTest.Infrastructure.Persistance;

namespace RunningHillTest.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<RunningHillDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("RunningHillConnection"),
                b => b.MigrationsAssembly(typeof(RunningHillDBContext).Assembly.FullName)), ServiceLifetime.Transient);

            services.AddScoped<IRunningHillDBContext>(provider => provider.GetService<RunningHillDBContext>());
            return services;
        }
    }
}