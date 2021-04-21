using CarPark.Contracts.Interfaces;
using CarPark.Contracts.Interfaces.Logger;
using CarPark.Entities.Context;
using CarPark.LoggerService;
using CarPark.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarPark.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureLoggerManager(this IServiceCollection services) =>
            services.AddScoped<ILoggerManager, LoggerManager>();


        public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
        });

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            
    }
}
