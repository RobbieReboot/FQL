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

            
            lexer.RemoveErrorListeners(); // Remove default listeners
            FQLParser.RemoveErrorListeners();

            lexer.AddErrorListener(serviceManager.GetService<IAntlrErrorListener<int>>());
            FQLParser.AddErrorListener(serviceManager.GetService<CustomParserErrorListener>());

            var _visitor = serviceManager.GetService<IFQLVisitor>();
            _visitor.SetGrammarName(GrammarName);
            _visitor.ErrorManager.Info(0,0, GrammarName,$"Starting Execution on {DateTime.Now}");

            dynamic result;
            try
            {
                var tree = FQLParser.program();         // does initial token Scan/

                result = _visitor.Visit(tree);                       // Starts interpreter.
            }
            catch (Exception)                                        // For the HALT thrown from any Fatal severity error.
            {
                result = false;
            }

            if (_visitor.ErrorManager.HasErrors(FQLErrorSeverity.Warning))
            {
                Console.WriteLine("\nError Log"); 
                Console.WriteLine(new string('-',80));
                _visitor.ErrorManager.Show();
            }

            return result ?? true;
        }
    }
}
