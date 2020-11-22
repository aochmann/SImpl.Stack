using System;
using System.Collections.Generic;
using Novicell.App.Console.AppBuilders;
using Novicell.App.Console.Configuration;

namespace Novicell.App.Console.Extensions.Configuration
{
    public class CompositeStartupConfiguration : IStartupConfiguration
    {
        private readonly IList<IStartup> _startups = new List<IStartup>();
        
        public void UseStartup<TStartup>()
            where TStartup : IStartup, new()
        {
            _startups.Add(new ConfigurableStartup(appBuilder =>
            {
                new TStartup().Configuration(appBuilder);
            }));
        }
        
        public void UseStartup(Action<IAppBuilder> appBuilder)
        {
            _startups.Add(new ConfigurableStartup(appBuilder));
        }
        
        public void UseStartup(IStartup startup)
        {
            _startups.Add(startup);
        }
        
        public IStartup GetConfiguredStartup()
        {
            return new ConfigurableStartup(appBuilder =>
            {
                foreach (var startup in _startups)
                {
                    startup.Configuration(appBuilder);
                }
            });
        }
    }
}