using Antlr4.Runtime;
using FQL.Parser;

namespace AntlrCSharpTests;
[TestClass]
public class AssignmentTests
{
    private SymbolTable SymbolTable => FQLVisitor.SymbolTable;

    private FQLParser Arrange(string text)
    {
        //Clean out old symbols
        FQLVisitor.SymbolTable.Clear();
        
        AntlrInputStream inputStream = new AntlrInputStream(text);
        FQLLexer fqlLexer = new FQLLexer(inputStream);
        CommonTokenStream commonTokenStream = new CommonTokenStream(fqlLexer);
        FQLParser fqlParser= new FQLParser(commonTokenStream);

        return fqlParser;
    }
    [TestMethod]
    public void VariableDeclarationShouldAddToSymbolTable()
    {
        FQLParser parser = Arrange("var aSymbol = \"something\"");

        var context = parser.assignment();
        FQLVisitor visitor = new FQLVisitor();
        visitor.Visit(context);

        Assert.AreEqual("something", SymbolTable["aSymbol"]);
    }

    [TestMethod]
    public void AssignmentShouldCalculateExpression()
    {
        FQLParser parser = Arrange("var result = 3+2");

        var context = parser.assignment();
        FQLVisitor visitor = new FQLVisitor();
        var result = visitor.Visit(context);

        Assert.AreEqual(5.0, (double)SymbolTable["result"]);
    }
    [TestMethod]
    public void AssignmentShouldAssignStringLiteral()
    {
        FQLParser parser = Arrange("var result = \"Hello World\";");

        var context = parser.assignment();
        FQLVisitor visitor = new FQLVisitor();
        var result = visitor.Visit(context);

        Assert.AreEqual("Hello World", SymbolTable["result"]);
    }

    [TestMethod]
    public void AssignmentShouldAssignInterpolatedString()
    {
        FQLParser parser = Arrange("var result = $\"{Var1} {Var2}\";");
        SymbolTable.Add("Var1", "Hello");
        SymbolTable.Add("Var2", "World");

        var context = parser.assignment();
        FQLVisitor visitor = new FQLVisitor();
        var result = visitor.Visit(context);

        Assert.AreEqual("Hello World", SymbolTable["result"]);
    }
}