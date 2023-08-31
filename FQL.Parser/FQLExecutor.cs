using System.Runtime.ExceptionServices;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree.Pattern;

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
            visitor.ErrorManager.Add(new FQLError(new ParserRuleContext(){Start = new TokenTagToken("program",0){Line = 0,Column = 0}}, GrammarName,
                $"Starting Execution on {DateTime.Now}", FQLErrorSeverity.Info));
            try
            {
                visitor.Visit(tree);
            }
            catch (Exception ex)
            {
                return false;
            }

            if (visitor.ErrorManager.HasErrors(FQLErrorSeverity.Info))
                visitor.ErrorManager.Show();

            return true;
        }
    }
}
