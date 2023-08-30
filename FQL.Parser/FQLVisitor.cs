﻿using System.Runtime.ExceptionServices;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;

namespace FQL.Parser
{
    public partial class FQLVisitor : FQLParserBaseVisitor<object>
    {
        private readonly IStateManager _stateManager;

        public FQLVisitor(string grammarName = "Unknown")
        {
            _stateManager = ServiceManager.ServiceProvider.GetRequiredService<IStateManager>();
            StateManager.GrammarName = grammarName;
        }

        public IStateManager StateManager => _stateManager;

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
