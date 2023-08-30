using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FQL.Parser
{
    public class StateManager : IStateManager
    {
        public SymbolTable _symbolTable = new SymbolTable();
        public SymbolTable SymbolTable => _symbolTable;

        //To keep track of call hierarchy.
        public Stack<KeyValuePair<string, FQLParser.FunctionDefinitionContext>> _functionCallStack =
            new Stack<KeyValuePair<string, FQLParser.FunctionDefinitionContext>>(128);
        public Stack<KeyValuePair<string, FQLParser.FunctionDefinitionContext>> FunctionCallStack => _functionCallStack;

        //for functions implementation
        public Dictionary<string, List<string>> _functionParameters = new Dictionary<string, List<string>>();
        public Dictionary<string, List<string>> FunctionParameters => _functionParameters;

        // Function definitions as they're parsed.
        public Dictionary<string, FQLParser.FunctionDefinitionContext> _functionDefinitions =
            new Dictionary<string, FQLParser.FunctionDefinitionContext>(128);
        public Dictionary<string, FQLParser.FunctionDefinitionContext> FunctionDefinitions => _functionDefinitions;

        //TO allow nested loops to break out of the innermost loop only.
        public Stack<bool> _loopBreakStack = new Stack<bool>();
        public Stack<bool> LoopBreakStack => _loopBreakStack;

        public string GrammarName { get; set; }

        public StateManager()
        {
            GrammarName = "Unknown";
        }

    }
}
