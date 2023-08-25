using Antlr4.Runtime;
using FQL.Parser;
using Microsoft.Extensions.DependencyInjection;

namespace FQL.Tests;
[TestClass]
public class ExpressionEvaluatorTest
{
    private IStateManager _stateManager = null!;
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
    public void ExpressionShouldCalculateAddition()
    {
        FQLParser parser = Arrange("3+2");

        var context = parser.expression();
        FQLVisitor visitor = new FQLVisitor();
        var result = visitor.Visit(context);

        Assert.AreEqual(result, 5.0);
    }
    [TestMethod]
    public void ExpressionShouldCalculateSubtraction()
    {
        FQLParser parser = Arrange("5-2");

        var context = parser.expression();
        FQLVisitor visitor = new FQLVisitor();
        var result = visitor.Visit(context);

        Assert.AreEqual(result, 3.0);
    }
    [TestMethod]
    public void ExpressionShouldCalculateMultiplication()
    {
        FQLParser parser = Arrange("5*2");

        var context = parser.expression();
        FQLVisitor visitor = new FQLVisitor();
        var result = visitor.Visit(context);

        Assert.AreEqual(result, 10.0);
    }
    [TestMethod]
    public void ExpressionShouldRespectBODMAS()
    {
        FQLParser parser = Arrange("(3+5)*2+4");

        var context = parser.expression();
        FQLVisitor visitor = new FQLVisitor();
        var result = visitor.Visit(context);

        Assert.AreEqual(result, 20.0);
    }
    [TestMethod]
    public void ExpressionShouldCalculateFloatAddition()
    {
        FQLParser parser = Arrange("3.5+2.5");

        var context = parser.expression();
        FQLVisitor visitor = new FQLVisitor();
        var result = visitor.Visit(context);

        Assert.AreEqual(result, 6.0);
    }

    [TestMethod]
    public void ExpressionShouldCalculateParenthesisedExpression()
    {
        FQLParser parser = Arrange("10*(5+5)");

        var context = parser.expression();
        FQLVisitor visitor = new FQLVisitor();
        double result = (double)visitor.Visit(context);

        Assert.AreEqual(result, 100.0);
    }

    



}