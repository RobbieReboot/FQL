using Antlr4.Runtime;
using FQL.Parser;
using Microsoft.Extensions.DependencyInjection;

namespace FQL.Tests;
[TestClass]
public class FunctionCallTests
{
    private IStateManager _stateManager;
    [TestInitialize]
    public void Init()
    {
        using var serviceProvider = ServiceManager.BuildServiceProvider();
        _stateManager = serviceProvider.GetRequiredService<IStateManager>();
    }

    private FQLParser Arrange(string text)
    {
        //Clean out old symbols
        _stateManager.SymbolTable.Clear();
        
        AntlrInputStream inputStream = new AntlrInputStream(text);
        FQLLexer fqlLexer = new FQLLexer(inputStream);
        CommonTokenStream commonTokenStream = new CommonTokenStream(fqlLexer);
        FQLParser fqlParser= new FQLParser(commonTokenStream);

        return fqlParser;
    }

    [TestMethod]
    public void FunctionCallShouldEvaluateParameters()
    {
        FQLParser parser = Arrange(
            "function TestFunc(h,w) { return $\"{h} {w}\"; }" +
            "return call TestFunc(\"Hello\",\"World\"); ");

        var context = parser.program();
        FQLVisitor visitor = new FQLVisitor(_stateManager);
        var result = visitor.Visit(context);

        Assert.AreEqual(result, "Hello World");
    }
}