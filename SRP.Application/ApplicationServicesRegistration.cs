using FluentValidation;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.Extensions.Configuration.Json;

using SRP.Application.Contracts.Infrastructure;
using SRP.Infrastructure.Caching;

using StackExchange.Redis;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application
{
    public static class ApplicationServicesRegistration
    {
        private static readonly string REDIS_CONNECTION = "REDIS_CONNECTION";
        /// <summary>
        /// This method is used to register all application services.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            /**
             * By doing <see cref="services.AddAutoMapper(Assembly.GetExecutingAssembly())"/> , 
             * the DI Container engine will traverse all assemblies and find all classes 
             * that inherit from Automapper Profile class.
             * This is a short-cut for <see cref="services.AddAutoMapper(typeof(MappingProfile)"/>
             * which requires adding all the different profile classes where multiple ones have been defined.
             */
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // MediatR. Note that new MediatR requires configuration
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            // FluentValidation
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMemoryCache();

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "REDIS_CONNECTION";
                options.InstanceName = "redis-stack";
            });
            // Redis
            var tBuilder = new ConfigurationBuilder();   
            var tConfigRoot = tBuilder
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var tRedisConnection = tConfigRoot[REDIS_CONNECTION]?? tConfigRoot.GetSection(REDIS_CONNECTION).ToString();
            if(string.IsNullOrWhiteSpace(tRedisConnection))
                throw new Exception($"Environmental variable for {REDIS_CONNECTION} not found!");

            //services.AddSingleton<IConnectionMultiplexer>(
            //    ConnectionMultiplexer.Connect(tRedisConnection));
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = tRedisConnection;
                options.InstanceName = "redis-stack";
            });
            
            services.AddScoped<ICacheBase, MemoryCacheBase>();
 
            // Return the services that have been configured
            return services;
        }
    }
}
