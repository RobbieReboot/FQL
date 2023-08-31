using System.Runtime.ExceptionServices;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;

namespace FQL.Parser
{
  public partial class FQLVisitor : FQLParserBaseVisitor<object>, IFQLVisitor
  {
        private readonly IStateManager _stateManager;
        private readonly IErrorManager _errorManager;

        public FQLVisitor(IStateManager stateManager,IErrorManager errManager, string grammarName = "Unknown")
        {

            _stateManager = stateManager;
            _errorManager = errManager;

            StateManager.GrammarName = grammarName;
        }

        public IStateManager StateManager => _stateManager;
        public IErrorManager ErrorManager => _errorManager;

        public void SetGrammarName(string grammarName)
        {
            StateManager.GrammarName = grammarName;
        }

        private bool _hasReturned = false;
        
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
