using System.Runtime.ExceptionServices;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System.Text;
using System.Text.RegularExpressions;

namespace FQL.Parser
{
    public partial class FQLVisitor : FQLParserBaseVisitor<object>
    {
   
        public FQLVisitor() { }


        private bool _hasReturned = false;
        public FQLVisitor(string fileName="NoFile") => StateManager.GrammarName = fileName;
 
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