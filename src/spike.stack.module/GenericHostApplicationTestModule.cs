using System.Threading.Tasks;
using SImpl.Stack.ApplicationBuilders;
using SImpl.Stack.Modules;

namespace spike.stack.module
{
    public class GenericHostApplicationTestModule : IGenericHostApplicationModule
    {
        public void Configure(IGenericHostApplicationBuilder builder)
        {
            
        }

        public Task StartAsync()
        {
            return Task.CompletedTask;
        }

        public Task StopAsync()
        {
            return Task.CompletedTask;
        }

        public string Name => nameof(GenericHostApplicationTestModule);
    }
    
    public static partial class AppBuilderExtension
    {
        public static void UseGenericHostApplicationTestModule(this IGenericHostApplicationBuilder applicationBuilder)
        {
            applicationBuilder.AttachNewGenericHostStackAppModuleOrGetConfigured(() => new GenericHostApplicationTestModule());
        }
    }
}