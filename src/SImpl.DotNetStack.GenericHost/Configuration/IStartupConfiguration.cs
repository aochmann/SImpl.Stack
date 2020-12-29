using System;
using Microsoft.Extensions.DependencyInjection;
using SImpl.DotNetStack.ApplicationBuilders;
using SImpl.DotNetStack.Configurations;

namespace SImpl.DotNetStack.GenericHost.Configuration
{
    public interface IStartupConfiguration
    {
        void UseStartup<TStartup>()
            where TStartup : IStartup, new(); // TODO: Open startup

        void UseStartup(Action<IDotNetStackApplicationBuilder> appBuilder);
        
        void UseStartup(IStartup startup);
        
        void UseServiceConfiguration(Action<IServiceCollection> services);
        
        IStartup GetConfiguredStartup();
    }
}