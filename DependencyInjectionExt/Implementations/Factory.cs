using System;
using DependencyInjectionExt.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjectionExt.Implementations
{
    public class Factory<TService> : IFactory<TService>
    {
        readonly IServiceProvider _services;

        public Factory(IServiceProvider services)
        {
            _services = services;
        }

        public TService Create()
        {
            return _services.GetRequiredService<TService>();
        }
    }
}