using Antlr4.Runtime;
using FQL.Parser;
using Microsoft.Extensions.DependencyInjection;

namespace FQL.Tests;
[TestClass]
public class ExpressionEvaluatorTest
{
    private IStateManager _stateManager = null!;
    private IFQLVisitor _visitor= null!;

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
    public void ExpressionShouldCalculateAddition()
    {
        FQLParser parser = Arrange("3+2");

        var context = parser.expression();
        var result = _visitor.Visit(context);

        Assert.AreEqual(result, 5);
    }
    [TestMethod]
    public void ExpressionShouldCalculateSubtraction()
    {
        FQLParser parser = Arrange("5-2");

        var context = parser.expression();
        var result = _visitor.Visit(context);

        Assert.AreEqual(result, 3);
    }
    [TestMethod]
    public void ExpressionShouldCalculateMultiplication()
    {
        FQLParser parser = Arrange("5*2");

        var context = parser.expression();
        var result = _visitor.Visit(context);

        Assert.AreEqual(result, 10);
    }
    [TestMethod]
    public void ExpressionShouldRespectBODMAS()
    {
        FQLParser parser = Arrange("(3+5)*2+4");

        var context = parser.expression();
        var result = _visitor.Visit(context);

        Assert.AreEqual(result, 20);
    }
    [TestMethod]
    public void ExpressionShouldCalculateFloatAddition()
    {
        FQLParser parser = Arrange("3.5+2.5");

        var context = parser.expression();
        var result = _visitor.Visit(context);

        Assert.AreEqual(6.0f,result);
    }

    [TestMethod]
    public void ExpressionShouldCalculateParenthesisedExpression()
    {
        FQLParser parser = Arrange("10*(5+5)");

        var context = parser.expression();
        var result = _visitor.Visit(context);

        Assert.AreEqual(result, 100);
    }

    [TestMethod]
    public void ExpressionShouldUseVariablesExpression()
    {
        FQLParser parser = Arrange("10*(5+var1)");
        _stateManager.SymbolTable.Add("var1",5);
        var context = parser.expression();
        var result = _visitor.Visit(context);

        Assert.AreEqual(result, 100);
    }

    [TestMethod]
    public void ExpressionShouldTruncateIntViaTypePromotion()
    {
        //should perform the division as int arithmetic.
        FQLParser parser = Arrange("7/2");

        var context = parser.expression();
        var result = _visitor.Visit(context);

        Assert.AreEqual(result, 3);
    }


}