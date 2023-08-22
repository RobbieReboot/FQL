using Antlr4.Runtime;
using FQL.Parser;

namespace AntlrCSharpTests;
[TestClass]
public class FunctionCallTests
{
    private SymbolTable SymbolTable => FQLVisitor.SymbolTable;

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
            "function TestFunc(h,w) { return \"HELLO\"; }\n\r" +
            "call TestFunc(\"Hello\",\"World\"); ");
        //FQLParser parser = Arrange(
        //    "function TestFunc(h,w){ return $\"{h} {w}\"; }\n\r" +
        //    "call TestFunc(\"Hello\",\"World\"); ");

        var context = parser.callStatement();
        FQLVisitor visitor = new FQLVisitor();
        var result = visitor.Visit(context);

        Assert.AreEqual(result, true);
    }
}