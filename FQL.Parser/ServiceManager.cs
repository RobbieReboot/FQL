using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace FQL.Parser
{
    /// <summary>
    /// Handles all the IoC  for the FQL parser.
    /// </summary>
    public static class ServiceManager
    {
        private static ServiceProvider _serviceProvider;

        public static ServiceProvider ServiceProvider=> _serviceProvider;

        static ServiceManager()
        {
            BuildServiceProvider();
        }

        public static ServiceProvider BuildServiceProvider()
        {
            var _serviceCollection = new ServiceCollection();
            _serviceCollection.AddSingleton<IStateManager, StateManager>();
            _serviceCollection.AddSingleton<IErrorManager, ErrorManager>();

            _serviceProvider =_serviceCollection.BuildServiceProvider();
            return _serviceProvider;
        }
    }
}
