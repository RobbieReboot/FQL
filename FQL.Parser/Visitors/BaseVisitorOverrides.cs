using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System.Text;
using System.Text.RegularExpressions;

namespace FQL.Parser
{
    public partial class ProgramVisitor : FQLParserBaseVisitor<object>
    {
        public static SymbolTable _symbolTable = new SymbolTable();
        public static Stack<KeyValuePair<string,object>> _interpreterStack = new Stack<KeyValuePair<string,object>>();

        private bool hasReturned = false;

        protected override bool ShouldVisitNextChild(IRuleNode node, object currentResult)
        {
            // If we've hit a return statement, don't visit further children
            if (hasReturned)
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