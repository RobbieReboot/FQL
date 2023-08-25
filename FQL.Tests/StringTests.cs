using Antlr4.Runtime;
using FQL.Parser;
using Microsoft.Extensions.DependencyInjection;

namespace FQL.Tests;
[TestClass]
public class StringTests
{
    private IStateManager _stateManager = null!;
    [TestInitialize]
    public void Init()
    {
        var serviceProvider = ServiceManager.BuildServiceProvider();
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
    public void InterpolationStringShouldReturnInterpolatedString()
    {
        FQLParser parser = Arrange("$\"{Var1} {Var2}\"");
        _stateManager.SymbolTable.Add("Var1", "Hello");
        _stateManager.SymbolTable.Add("Var2", "World");

        var context = parser.@string();
        FQLVisitor visitor = new FQLVisitor();
        var result = visitor.Visit(context);

        Assert.AreEqual(result, "Hello World");
    }
    [TestMethod]
    public void StringLiteralShouldReturnKnownString()
    {
        FQLParser parser = Arrange("\"Hello World\";");

        FQLVisitor visitor = new FQLVisitor();
        var context = parser.@string();
        var result = visitor.Visit(context);

        Assert.AreEqual("Hello World", result);
    }
}