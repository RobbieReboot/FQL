using Antlr4.Runtime;
using FQL.Parser;
using Microsoft.Extensions.DependencyInjection;

namespace FQL.Tests;
[TestClass]
public class AssignmentTests
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
    public void VariableDeclarationShouldAddToSymbolTable()
    {
        FQLParser parser = Arrange("var aSymbol = \"something\"");

        var context = parser.assignment();
        _visitor.Visit(context);

        Assert.AreEqual("something", _stateManager.SymbolTable["aSymbol"]);
    }

    [TestMethod]
    public void AssignmentShouldCalculateExpression()
    {
        FQLParser parser = Arrange("var result = 3+2");

        var context = parser.assignment();
        var result = _visitor.Visit(context);

        Assert.AreEqual(5, _stateManager.SymbolTable["result"]);
    }

    [TestMethod]
    public void ComplexAssignmentShouldAssignValue()
    {
        FQLParser parser = Arrange(
            """
            var x = 5;
            var y = x;
            return y;
            """);

        var context = parser.assignment();
        var result = _visitor.Visit(context);

        Assert.AreEqual(5, result);
    }

    [TestMethod]
    public void AssignmentShouldAssignStringLiteral()
    {
        FQLParser parser = Arrange("var result = \"Hello World\";");

        var context = parser.assignment();
        var result = _visitor.Visit(context);

        Assert.AreEqual("Hello World", _stateManager.SymbolTable["result"]);
    }

    [TestMethod]
    public void AssignmentShouldAssignInterpolatedString()
    {
        FQLParser parser = Arrange("var result = $\"{Var1} {Var2}\";");
        _stateManager.SymbolTable.Add("Var1", "Hello");
        _stateManager.SymbolTable.Add("Var2", "World");

        var context = parser.assignment();
        var result = _visitor.Visit(context);
        Assert.AreEqual("Hello World", _stateManager.SymbolTable["result"]);
    }

    [TestMethod]
    public void UnknownInterpolationSymbolShouldReturnEmptyStrings()
    {
        FQLParser parser = Arrange("var result = $\"XX{Var1x} YY{Var2}\";");

        var context = parser.assignment();
        var result = _visitor.Visit(context);

        Assert.AreEqual("XX YY", _stateManager.SymbolTable["result"]);
    }


    [TestMethod]
    public void AssignmentShouldAssignInt()
    {
        FQLParser parser = Arrange("var result = 45;");

        var context = parser.assignment();
        var result = _visitor.Visit(context);

        Assert.AreEqual(typeof(int), _stateManager.SymbolTable["result"].GetType());
        Assert.AreEqual(45, _stateManager.SymbolTable["result"]);

    }

    [TestMethod]
    public void AssignmentShouldAssignFloat()
    {
        FQLParser parser = Arrange("var result = 45.0f;");

        var context = parser.assignment();
        var result = _visitor.Visit(context);

        Assert.AreEqual(typeof(float), _stateManager.SymbolTable["result"].GetType());
        Assert.AreEqual(45.0f, _stateManager.SymbolTable["result"]);

    }


    [TestMethod]
    public void AssignmentShouldAssignDoubleWithSuffix()
    {
        FQLParser parser = Arrange("var result = 45.0d;");

        var context = parser.assignment();
        var result = _visitor.Visit(context);

        Assert.AreEqual(typeof(double), _stateManager.SymbolTable["result"].GetType());
        Assert.AreEqual(45.0d, _stateManager.SymbolTable["result"]);

    }
    [TestMethod]
    public void AssignmentShouldAssignByDoubleWithNoSuffix()
    {
        FQLParser parser = Arrange("var result = 45.0;");
        var context = parser.assignment();
        var result = _visitor.Visit(context);

        Assert.AreEqual(typeof(double), _stateManager.SymbolTable["result"].GetType());
        Assert.AreEqual(45.0d, _stateManager.SymbolTable["result"]);

    }

}