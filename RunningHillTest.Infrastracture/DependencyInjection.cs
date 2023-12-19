using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RunningHillTest.Application.Interfaces;
using RunningHillTest.Application.Mappers;
using RunningHillTest.Domain.Entities;
using RunningHillTest.Domain.Interfaces;
using RunningHillTest.Infrastructure.Persistance;
using RunningHillTest.Infrastructure.Persistance.Repository;
using RunningHillTest.Infrastructure.Persistance.Services;
using System.Reflection;

namespace RunningHillTest.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddDbContext<RunningHillDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("RunningHillConnection"),
                b => b.MigrationsAssembly(typeof(RunningHillDBContext).Assembly.FullName)), ServiceLifetime.Transient);

            services.AddScoped<IRunningHillDBContext,RunningHillDBContext>();
            services.AddScoped<IWordRepository, WordRepository>();
            services.AddScoped<IWordTypeRepository, WordTypeRepository>();
            services.AddScoped<ISentenceRepository, SentenceRepository>();
            services.AddScoped<ISentenceService, SentenceService>();
            services.AddScoped<IWordTypeService, WordTypeService>();
            services.AddScoped<IWordService, WordService>();

            return services;
        }
    }
}