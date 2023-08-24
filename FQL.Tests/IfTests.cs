using Antlr4.Runtime;
using FQL.Parser;
using Microsoft.Extensions.DependencyInjection;

namespace FQL.Tests;
[TestClass]
public class IfTests
{
    private IStateManager _stateManager;
    [TestInitialize]
    public void Init(TestContext context)
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
    public void IfTestShouldReturnTrue()
    {
        FQLParser parser = Arrange("if ( 1==1 ) { return true; }");

        var context = parser.@if();
        FQLVisitor visitor = new FQLVisitor(_stateManager);
        var result = visitor.Visit(context);

        Assert.AreEqual(result, true);
    }
}