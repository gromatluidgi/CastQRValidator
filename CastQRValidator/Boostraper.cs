using CastQRValidator.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CastQRValidator
{
    /// <summary>
    /// The boostraper static class is used as a single run entrypoint
    /// for load application configuration and dependencies.
    /// </summary>
    public static class Bootstraper
    {
        private static bool IsInitialized = false;

        public static IServiceProvider? ServiceProvider { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public static void Initialize()
        {
            if (IsInitialized) return;

            SetupIoc();

            IsInitialized = true;
        }

        private static void SetupIoc()
        {
            var services = new ServiceCollection();

            services.SetupConfiguration();
            services.AddViewModels();
            services.AddStores();
            services.AddApplicationServices();

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
