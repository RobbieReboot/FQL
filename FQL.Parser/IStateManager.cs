namespace FQL.Parser;

public interface IStateManager
{
    SymbolTable SymbolTable { get; }
    Stack<KeyValuePair<string, FQLParser.FunctionDefinitionContext>> FunctionCallStack { get; }
    Dictionary<string, List<string>> FunctionParameters { get; }
    Dictionary<string, FQLParser.FunctionDefinitionContext> FunctionDefinitions { get; }
    Stack<bool> LoopBreakStack { get; }
    string GrammarName { get; set; }
}