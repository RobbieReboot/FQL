using Antlr4.Runtime;
using FQL.Parser;
using Microsoft.Extensions.DependencyInjection;

namespace FQL.Tests;
[TestClass]
public class IfTests
{
    private IStateManager _stateManager = null!;
    private IFQLVisitor _visitor = null!;

    [TestInitialize]
    public void Init()
    {
        _stateManager = TestAssemblyInit._serviceProvider.GetService<IStateManager>()!;
    }

    private FQLParser Arrange(string text)
    {
        //Clean out old symbols
        _stateManager.SymbolTable.Clear();
        
        AntlrInputStream inputStream = new AntlrInputStream(text);
        FQLLexer fqlLexer = new FQLLexer(inputStream);
        CommonTokenStream commonTokenStream = new CommonTokenStream(fqlLexer);
        FQLParser fqlParser= new FQLParser(commonTokenStream);
        _visitor = TestAssemblyInit._serviceProvider.GetService<IFQLVisitor>() ?? throw new InvalidOperationException();

        return fqlParser;
    }

    [TestMethod]
    public void IfTestShouldReturnTrue()
    {
        FQLParser parser = Arrange("if ( 1==1 ) { return true; }");

        var context = parser.@if();
        var result = _visitor.Visit(context);

        Assert.AreEqual(true, result);
    }
}