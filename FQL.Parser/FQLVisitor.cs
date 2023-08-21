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

        public static Stack<KeyValuePair<string,object>> InterpreterStack = new Stack<KeyValuePair<string,object>>();

        //for functions implementation
        private Dictionary<string, List<string>> _functionParameters = new Dictionary<string, List<string>>();
        private Dictionary<string, FQLParser.FunctionDefinitionContext> _functionDefinitions =
            new Dictionary<string, FQLParser.FunctionDefinitionContext>(128);

        private bool _hasReturned = false;
        public string GrammarName { get; set; }
        public FQLVisitor(string fileName="NoFile") => GrammarName = fileName;
 
        protected override bool ShouldVisitNextChild(IRuleNode node, object currentResult)
        {
            // If we've hit a return statement, don't visit further children
            if (_hasReturned)
            {
                // Reset after executing a 'return' statement. This mechanism prevents parsing of future nodes
                // until we've implemented a stack for return values.
                //hasReturned = false;
               
                return false;
            }
            var result = base.ShouldVisitNextChild(node, currentResult);
            return result;
        }
    }
}