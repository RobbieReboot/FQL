using Antlr4.Runtime;
using FQL.Parser;
using Microsoft.Extensions.DependencyInjection;

namespace FQL.Tests;
[TestClass]
public class TestAssemblyInit
{
    //private IStateManager _stateManager = null!;
    private static ServiceManager _serviceManager = null!;
    public static ServiceProvider _serviceProvider = null!;

    [AssemblyInitialize]
    public static void AssemblyInit(TestContext context)
    {
        _serviceManager = new ServiceManager();
        _serviceProvider = _serviceManager.BuildServiceProvider();
    }
}