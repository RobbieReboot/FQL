using Antlr4.Runtime;
using FQL.Parser;

namespace FQL.Tests;
[TestClass]
public class FunctionCallTests
{
    private SymbolTable SymbolTable => StateManager.SymbolTable;

    private FQLParser Arrange(string text)
    {
        //Clean out old symbols
        SymbolTable.Clear();
        
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
        FQLVisitor visitor = new FQLVisitor();
        var result = visitor.Visit(context);

        Assert.AreEqual(result, "Hello World");
    }
}