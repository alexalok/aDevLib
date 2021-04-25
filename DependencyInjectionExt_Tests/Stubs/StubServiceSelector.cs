using System;
using DependencyInjectionExt.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjectionExt_Tests.Stubs
{
    public class StubServiceSelector : ISelector<IStubService>
    {
        readonly IServiceProvider _services;
        readonly bool _selectService1;

        public StubServiceSelector(IServiceProvider services, bool selectService1)
        {
            _services = services;
            _selectService1 = selectService1;
        }

        public IStubService Select()
        {
            return _selectService1
                ? (IStubService) _services.GetRequiredService<StubService1>()
                : _services.GetRequiredService<StubService2>();
        }
    }
}