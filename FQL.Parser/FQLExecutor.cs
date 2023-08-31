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
        private ServiceManager serviceManager { get; set; }
        public FQLScript()
        {
            serviceManager = new ServiceManager();
        }
        public FQLScript(string name) : this() => GrammarName = name;

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
            var _visitor = serviceManager.GetService<IFQLVisitor>();

            //FQLVisitor visitor = new FQLVisitor(GrammarName);
            _visitor.ErrorManager.Add(new FQLError(new ParserRuleContext(){Start = new TokenTagToken("program",0){Line = 0,Column = 0}}, GrammarName,
                $"Starting Execution on {DateTime.Now}", FQLErrorSeverity.Info));
            try
            {
                _visitor.Visit(tree);
            }
            catch (Exception ex)
            {
                return false;
            }

            if (_visitor.ErrorManager.HasErrors(FQLErrorSeverity.Info))
                _visitor.ErrorManager.Show();

            return true;
        }
    }
}
