using Antlr4.Runtime;
using FQL.Parser;

namespace AntlrCSharpTests;
[TestClass]
public class ParserTest
{
    private SymbolTable SymbolTable => ProgramVisitor._symbolTable;

    private FQLParser Arrange(string text)
    {
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
        ProgramVisitor visitor = new ProgramVisitor();
        visitor.Visit(context);

        Assert.AreEqual("something", SymbolTable["aSymbol"]);
    }

    [TestMethod]
    public void VariableDefinitionShouldCalculateExpression()
    {
        FQLParser parser = Arrange("var result = 3+2");

        var context = parser.assignment();
        ProgramVisitor visitor = new ProgramVisitor();
        var result = visitor.Visit(context);

        Assert.AreEqual(5, SymbolTable["result"]);
    }


    [TestMethod]
    public void ExpressionShouldCalculateAddition()
    {
        FQLParser parser = Arrange("3+2");

        var context = parser.expression();
        ProgramVisitor visitor = new ProgramVisitor();
        var result = visitor.Visit(context);

        Assert.AreEqual(result, 5);
    }


    [TestMethod]
    public void ExpressionShouldCalculateParenthesisedExpression()
    {
        FQLParser parser = Arrange("3+2+(5+10)");

        var context = parser.expression();
        ProgramVisitor visitor = new ProgramVisitor();
        var result = visitor.Visit(context);

        Assert.AreEqual(result, 20);
    }

    [TestMethod]
    public void ExpressionShouldReturnInterpolatedString()
    {
        SymbolTable.Add("Var1", "Hello");
        SymbolTable.Add("Var2", "World");
        FQLParser parser = Arrange("$\"{Var1} {Var2}\"");

        var context = parser.expression();
        ProgramVisitor visitor = new ProgramVisitor();
        var result = visitor.Visit(context);

        Assert.AreEqual(result, "Hello World");
    }



}