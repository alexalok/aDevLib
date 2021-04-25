using System;
using DependencyInjectionExt.Implementations;
using DependencyInjectionExt.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjectionExt
{
    public static class RegistrationExtensions
    {
        public static IServiceCollection AddSelector<TService, TSelector>(this IServiceCollection services)
            where TSelector : class, ISelector<TService>
            where TService : class
        {
            services.AddSingleton<TSelector>();
            services.AddTransient<TService>(s =>
            {
                var selector = s.GetRequiredService<TSelector>();
                return selector.Select();
            });
            return services;
        }

        public static IServiceCollection AddSelector<TService, TSelector>(this IServiceCollection services, Func<IServiceProvider, TSelector> selectorFactory)
            where TSelector : class, ISelector<TService>
            where TService : class
        {
            services.AddSingleton<TSelector>(selectorFactory);
            services.AddTransient<TService>(s =>
            {
                var selector = s.GetRequiredService<TSelector>();
                return selector.Select();
            });
            return services;
        }

        public static IServiceCollection AddFactoryFor<TService>(this IServiceCollection services)
            where TService : class
        {
            services.AddSingleton<IFactory<TService>, Factory<TService>>();
            services.AddTransient<TService>(s =>
            {
                var factory = s.GetRequiredService<IFactory<TService>>();
                return factory.Create();
            });
            return services;
        }
    }
}