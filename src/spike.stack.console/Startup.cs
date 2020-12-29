using Microsoft.Extensions.DependencyInjection;
using Novicell.App.DependencyInjection.Configuration;
using SImpl.DotNetStack.App.Extensions;
using SImpl.DotNetStack.ApplicationBuilders;
using SImpl.DotNetStack.Configurations;
using SImpl.DotNetStack.GenericHost.DependencyInjection;
using SImpl.DotNetStack.GenericHost.DependencyInjection.Configuration;
using SimpleInjector;
using spike.stack.app.Application;
using spike.stack.app.Domain;
using spike.stack.module;

namespace spike.stack.console
{
    public class Startup : IStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            
        }

        public void Configure(IDotNetStackApplicationBuilder stackBuilder)
        {
            stackBuilder.UseNovicellConsoleApp(consoleApp =>
            {
                consoleApp.UseHybridTestModule();
                consoleApp.Use<LegacyStackModule>();
                
                consoleApp.UseDependencyInjection(di =>
                {
                    /*di.UseGenericHost();
                    
                    di.RegisterServices(container =>
                    {
                        container.RegisterHostedService<GreetingHostedService>();
                        
                        container.Register<IGreetingAppService, GreetingAppService>(Lifestyle.Singleton);
                        container.Register<IGreetingService, SpanishGreetingService>(Lifestyle.Singleton);
                    });*/
                });
            });
        }
    }
}