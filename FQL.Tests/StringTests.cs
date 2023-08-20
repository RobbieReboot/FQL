using Antlr4.Runtime;
using FQL.Parser;

namespace AntlrCSharpTests;
[TestClass]
public class StringTests
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
    public void InterpolationStringShouldReturnInterpolatedString()
    {
        FQLParser parser = Arrange("$\"{Var1} {Var2}\"");
        SymbolTable.Add("Var1", "Hello");
        SymbolTable.Add("Var2", "World");

        var context = parser.@string();
        ProgramVisitor visitor = new ProgramVisitor();
        var result = visitor.Visit(context);

        Assert.AreEqual(result, "Hello World");
    }
    [TestMethod]
    public void StringLiteralShouldReturnKnownString()
    {
        FQLParser parser = Arrange("\"Hello World\";");

        ProgramVisitor visitor = new ProgramVisitor();
        var context = parser.@string();
        var result = visitor.Visit(context);

        Assert.AreEqual("Hello World", result);
    }
}