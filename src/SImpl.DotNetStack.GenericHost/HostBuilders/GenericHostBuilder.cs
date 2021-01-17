using System;
using Microsoft.Extensions.DependencyInjection;
using SImpl.DotNetStack.ApplicationBuilders;
using SImpl.DotNetStack.Configurations;
using SImpl.DotNetStack.GenericHost.Configuration;

namespace SImpl.DotNetStack.GenericHost.HostBuilders
{
    public class GenericHostBuilder : IGenericHostBuilder
    {
        private readonly IStartupConfiguration _config;

        public GenericHostBuilder(StartupConfiguration startupConfiguration)
        {
            _config = startupConfiguration;
        }

        public void UseStartup<TStartup>()
            where TStartup : IStartup, new()
        {
            _config.UseStartup<TStartup>();
        }
        
        public void Configure(Action<IDotNetStackApplicationBuilder> appBuilder)
        {
            _config.UseStartup(appBuilder);
        }
        
        public void ConfigureServices(Action<IServiceCollection> services)
        {
            _config.UseServiceConfiguration(services);
        }
        
        
    }
}