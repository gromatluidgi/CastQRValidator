using CastQRValidator.Attributes;
using CastQRValidator.Configurations;
using CastQRValidator.Stores;
using CastQRValidator.Stores.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Reflection;

namespace CastQRValidator.DependencyInjection
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            // Perform assembly scanning with dynamic view models registration
            services.Scan(s =>
            {
                s.FromCallingAssembly()
                .AddClasses(c => c.Where(p => p.Name.EndsWith("ViewModel") && p.IsDefined(typeof(TransientAttribute))))
                .AsSelf()
                .WithTransientLifetime();

                s.FromCallingAssembly()
                .AddClasses(c => c.Where(p => p.Name.EndsWith("ViewModel") && p.IsDefined(typeof(SingletonAttribute))))
                .AsSelf()
                .WithSingletonLifetime();
            });

            return services;
        }

        public static IServiceCollection AddJsonStores(this IServiceCollection services)
        {
            services.AddSingleton<IPlanStore, PlanStore>();
            services.AddSingleton<IRulesStore, RuleStore>();
            services.AddSingleton<ISampleStore, SampleStore>();
            services.AddSingleton<IEngineStore, EngineStore>();
            return services;
        }

        public static IServiceCollection AddScannedStores(this IServiceCollection services)
        {
            // Perform assembly scanning with dynamic stores registration
            services.Scan(s =>
            {
                s.FromCallingAssembly()
                .AddClasses(c => c.Where(p => p.Name.EndsWith("Store") && p.IsDefined(typeof(SingletonAttribute))))
                .AsSelfWithInterfaces()
                .WithSingletonLifetime();
            });

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Perform assembly scanning with dynamic application services registration
            services.Scan(s =>
            {
                s.FromCallingAssembly()
                .AddClasses(c => c.Where(p => p.Name.EndsWith("Service") && p.IsDefined(typeof(TransientAttribute))))
                .AsSelfWithInterfaces()
                .WithTransientLifetime();
            });

            return services;
        }


        public static IServiceCollection SetupConfiguration(this IServiceCollection services)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("Resources/appsettings.json");
            var configuration = builder.Build();
            services.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));
            return services;
        }
    }
}
