using System.Runtime.ExceptionServices;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;
using Antlr4.Runtime;

namespace FQL.Parser
{
    public class FQLScript
    {
        private string GrammarName { get; set; }
        public FQLScript() { }
        public FQLScript(string name) => GrammarName = name;

        public bool Execute()
        {
            var fqlScript= File.ReadAllText(GrammarName);

            var lexer = new FQLLexer(new AntlrInputStream(fqlScript));
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
            FQLVisitor visitor = new FQLVisitor(GrammarName);

            try
            {
                visitor.Visit(tree);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}
