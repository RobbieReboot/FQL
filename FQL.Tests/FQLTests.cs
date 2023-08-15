using Antlr4.Runtime;
using FQL.Parser;

namespace AntlrCSharpTests;
[TestClass]
public class ParserTest
{
    private FQLParser Setup(string text)
    {
        AntlrInputStream inputStream = new AntlrInputStream(text);
        FQLLexer fqlLexer = new FQLLexer(inputStream);
        CommonTokenStream commonTokenStream = new CommonTokenStream(fqlLexer);
        FQLParser fqlParser= new FQLParser(commonTokenStream);

        return fqlParser;
    }

    [TestMethod]
    public void SymbolDefinitionShouldAddToSymbolTable()
    {
        FQLParser parser = Setup("VAR aSymbol = \"something\"");

        var context = parser.varDeclaration();
        ProgramVisitor visitor = new ProgramVisitor();
        visitor.Visit(context);

        Assert.AreEqual("something", ProgramVisitor._symbolTable["aSymbol"]);
    }

    [TestMethod]
    public void TestLine()
    {
        //FQLParser parser = Setup("john says \"hello\" \n");

        //FQLParser.LineContext context = parser.line();
        //BasicFQLVisitor visitor = new BasicFQLVisitor();
        //FQLLine line = (FQLLine)visitor.VisitLine(context);

        //Assert.AreEqual("john", line.Person);
        //Assert.AreEqual("hello", line.Text);
    }

    [TestMethod]
    public void TestWrongLine()
    {
        //FQLParser parser = Setup("john sayan \"hello\" \n");

        //var context = parser.line();

        //Assert.IsInstanceOfType(context, typeof(FQLParser.LineContext));
        //Assert.AreEqual("john", context.name().GetText());
        //Assert.IsNull(context.SAYS());
        //Assert.AreEqual("johnsayan\"hello\"\n", context.GetText());
    }
}