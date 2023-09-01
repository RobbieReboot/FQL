using Antlr4.Runtime;
using FQL.Parser;
using Microsoft.Extensions.DependencyInjection;

namespace FQL.Tests;
[TestClass]
public class StringTests
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
        _visitor = TestAssemblyInit._serviceProvider.GetService<IFQLVisitor>()!;

        return fqlParser;
    }

    [TestMethod]
    public void InterpolationStringShouldReturnInterpolatedString()
    {
        FQLParser parser = Arrange("$\"{Var1} {Var2}\"");
        _stateManager.SymbolTable.Add("Var1", "Hello");
        _stateManager.SymbolTable.Add("Var2", "World");

        var context = parser.@string();
        var result = _visitor.Visit(context);

        Assert.AreEqual(result, "Hello World");
    }

    [TestMethod]
    public void StringLiteralShouldReturnKnownString()
    {
        FQLParser parser = Arrange("\"Hello World\";");

        var context = parser.@string();
        var result = _visitor.Visit(context);

        Assert.AreEqual("Hello World", result);
    }

    [TestMethod]
    public void UnknownInterpolationSymbolShouldGiveEmptyStrings()
    {
        FQLParser parser = Arrange("var result = $\"XX{Var1x} YY{Var2}\";");

        var context = parser.assignment();
        var result = _visitor.Visit(context);

        Assert.AreEqual("XX YY", _stateManager.SymbolTable["result"]);
    }
}