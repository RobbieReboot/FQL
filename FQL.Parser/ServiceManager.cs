using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace FQL.Parser
{
    public class ServiceManager
    {
        public static ServiceProvider BuildServiceProvider()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IStateManager, StateManager>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
