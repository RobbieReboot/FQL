using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Microsoft.Extensions.DependencyInjection;

namespace FQL.Parser
{
    /// <summary>
    /// Handles all the IoC  for the FQL parser.
    /// </summary>
    public class ServiceManager
    {
        private ServiceProvider _serviceProvider;

        public ServiceProvider ServiceProvider=> _serviceProvider;

        public ServiceManager()
        {
            BuildServiceProvider();
        }

        public ServiceProvider BuildServiceProvider()
        {
            var _serviceCollection = new ServiceCollection();
            _serviceCollection.AddSingleton<IStateManager, StateManager>();
            _serviceCollection.AddSingleton<IErrorManager, ErrorManager>();
            _serviceCollection.AddTransient<IFQLVisitor, FQLVisitor>();
            _serviceCollection.AddTransient<IAntlrErrorListener<int>, CustomLexerErrorListener>();
            _serviceCollection.AddTransient<CustomParserErrorListener>();

            _serviceProvider =_serviceCollection.BuildServiceProvider();
            return _serviceProvider;
        }

        public T GetService<T>() where T : notnull
        {
            return ServiceProvider.GetRequiredService<T>();
        }
    }
}
