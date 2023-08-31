using Antlr4.Runtime;
using FQL.Parser;
using Microsoft.Extensions.DependencyInjection;

namespace FQL.Tests;
[TestClass]
public class FunctionCallTests
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
    public void FunctionCallShouldEvaluateParameters()
    {
        FQLParser parser = Arrange(
            "function TestFunc(h,w) { return $\"{h} {w}\"; }" +
            "return TestFunc(\"Hello\",\"World\"); ");

        var context = parser.program();
        var result = _visitor.Visit(context);

        Assert.AreEqual(result, "Hello World");
    }
    [TestMethod]
    public void ComplexParametersShouldBeEvaluated()
    {
        FQLParser parser = Arrange(
            """
               function GetHello() { return "Hello"; }
               function TestFunc(h,w) { return $"{h} {w}"; }
                           
               return TestFunc(GetHello(),"World"); 
            """
            );

        var context = parser.program();
        var result = _visitor.Visit(context);

        Assert.AreEqual("Hello World", result); 
    }
}
