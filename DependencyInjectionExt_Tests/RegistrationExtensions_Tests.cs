using System;
using DependencyInjectionExt;
using DependencyInjectionExt_Tests.Stubs;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace DependencyInjectionExt_Tests
{
    public class RegistrationExtensions_Tests
    {
        [Fact]
        public void AddSelector_Ensure_Selects_Correctly()
        {
            var services = new ServiceCollection();
            services.AddSelector<IStubService, StubServiceSelector>(s =>
                new StubServiceSelector(s, true));
            services.AddFactoryFor<StubService1>();
            services.AddFactoryFor<StubService2>();

            IServiceProvider provider = services.BuildServiceProvider();
            var service = provider.GetRequiredService<IStubService>();

            Assert.IsType<StubService1>(service);
        }

        [Fact]
        public void AddFactoryFor_Ensure_Factory_Creates_Correctly()
        {
            var services = new ServiceCollection();
            services.AddSelector<IStubService, StubServiceSelector>();
        }
    }
}