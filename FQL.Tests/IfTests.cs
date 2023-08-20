using Antlr4.Runtime;
using FQL.Parser;

namespace AntlrCSharpTests;
[TestClass]
public class IfTests
{
    private SymbolTable SymbolTable => ProgramVisitor._symbolTable;

    private FQLParser Arrange(string text)
    {
        //Clean out old symbols
        ProgramVisitor._symbolTable.Clear();
        
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
        ProgramVisitor visitor = new ProgramVisitor();
        var result = visitor.Visit(context);

        Assert.AreEqual(result, true);
    }
}