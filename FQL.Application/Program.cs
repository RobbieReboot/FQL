using Antlr4.Runtime;
using System.Text;
using FQL;
using FQL.Parser;

//"Data Source=.\;Integrated Security=SSPI;Initial Catalog=FormsMiddlewareDevUAT;MultipleActiveResultSets=True;app=LINQPad;Encrypt=true;TrustServerCertificate=true"
try
{
    var grammarName = "FQLTest.fql";
    var fqlProgram= File.ReadAllText(grammarName);

    var lexer = new FQLLexer(new AntlrInputStream(fqlProgram));
    var tokens = new CommonTokenStream(lexer);

    //tokens.Fill();
    //Console.WriteLine("Dumping Tokens");
    //Console.WriteLine("--------------");
    //foreach (var token in tokens.GetTokens())
    //{
    //    Console.WriteLine(token);
    //}

    FQLParser FQLParser = new FQLParser(tokens);
    var tree = FQLParser.program();
    ProgramVisitor visitor = new ProgramVisitor(grammarName);
    visitor.Visit(tree);
    Console.WriteLine("Dumping Symbols");
    Console.WriteLine("---------------");
    ProgramVisitor._symbolTable.Dump();

}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex);
}

