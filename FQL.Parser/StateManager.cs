using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FQL.Parser
{
    public class StateManager
    {
        public static readonly SymbolTable SymbolTable = new SymbolTable();

        //To keep track of call hierarchy.
        public static  Stack<KeyValuePair<string, FQLParser.FunctionDefinitionContext>> FunctionCallStack =
            new Stack<KeyValuePair<string, FQLParser.FunctionDefinitionContext>>(128);

        //for functions implementation
        public static Dictionary<string, List<string>> FunctionParameters = new Dictionary<string, List<string>>();

        // Function definitions as they're parsed.
        public static Dictionary<string, FQLParser.FunctionDefinitionContext> FunctionDefinitions =
            new Dictionary<string, FQLParser.FunctionDefinitionContext>(128);
        public static string GrammarName { get; set; }

    }
}
