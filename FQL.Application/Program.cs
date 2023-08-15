using Antlr4.Runtime;
using System.Text;
using FQL;
using FQL.Parser;

//"Data Source=.\;Integrated Security=SSPI;Initial Catalog=FormsMiddlewareDevUAT;MultipleActiveResultSets=True;app=LINQPad;Encrypt=true;TrustServerCertificate=true"
try
{
    var fqlProgram= File.ReadAllText("FQLTest.fql");

    var lexer = new FQLLexer(new AntlrInputStream(fqlProgram));
    var tokens = new CommonTokenStream(lexer);

    tokens.Fill();
    Console.WriteLine("Dumping Tokens");
    Console.WriteLine("--------------");

    foreach (var token in tokens.GetTokens())
    {
        Console.WriteLine(token);
    }

    FQLParser FQLParser = new FQLParser(tokens);
    var tree = FQLParser.program();
    ProgramVisitor visitor = new ProgramVisitor();
    visitor.Visit(tree);
}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex);
}

