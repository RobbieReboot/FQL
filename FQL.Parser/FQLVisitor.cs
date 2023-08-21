using System.Runtime.ExceptionServices;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System.Text;
using System.Text.RegularExpressions;

namespace FQL.Parser
{
    public partial class FQLVisitor : FQLParserBaseVisitor<object>
    {
        public static readonly SymbolTable SymbolTable = new SymbolTable();
        public FQLVisitor() { }

        //To keep track of call hierarchy.
        private Stack<KeyValuePair<string, FQLParser.FunctionDefinitionContext>> _functionCallStack =
            new Stack<KeyValuePair<string, FQLParser.FunctionDefinitionContext>>(128);
        
        //for functions implementation
        private Dictionary<string, List<string>> _functionParameters = new Dictionary<string, List<string>>();
        
        // Function definitions as they're parsed.
        private Dictionary<string, FQLParser.FunctionDefinitionContext> _functionDefinitions =
            new Dictionary<string, FQLParser.FunctionDefinitionContext>(128);

        private bool _hasReturned = false;
        public string GrammarName { get; set; }
        public FQLVisitor(string fileName="NoFile") => GrammarName = fileName;
 
        // Overridden ShouldVisitNextChild that is Return statement aware.
        protected override bool ShouldVisitNextChild(IRuleNode node, object currentResult)
        {
            // If we've hit a return statement, don't visit further children!
            if (_hasReturned)
            {
                return false;
            }
            var result = base.ShouldVisitNextChild(node, currentResult);
            return result;
        }
    }
}