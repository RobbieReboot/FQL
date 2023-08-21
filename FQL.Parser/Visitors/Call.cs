namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitCallStatement(FQLParser.CallStatementContext context)
    {
        string functionName = context.identifier().GetText();

        if (!_functionDefinitions.ContainsKey(functionName))
        {
            throw new Exception($"Undefined function: {functionName}");
        }
        // Create call stack prologue

        _functionCallStack.Push(new KeyValuePair<string,FQLParser.FunctionDefinitionContext>(functionName, _functionDefinitions[functionName]));

        // Create a new scope for the function
        var callingScope = SymbolTable.CurrentScope;
        // open new scope for function scope.
        SymbolTable.Push();

        // Map passed arguments to function parameters
        var arguments = context.callParamList().identifier().Select(arg => arg.GetText()).ToList();
        var parameters = _functionParameters[functionName];

        if (arguments.Count != parameters.Count)
        {
            throw new Exception($"Function {functionName} expects {parameters.Count} parameters but got {arguments.Count}.");
        }

        for (int i = 0; i < arguments.Count; i++)
        {
            //Add to current scope - EMULATE PASS BY VALUE!
            SymbolTable.Add(parameters[i], (string)callingScope[arguments[i].ToString()]!);
        }

        // Now, evaluate the function body
        var functionBody = _functionDefinitions[functionName].statements().children;
        object? lastReturnValue = null;
        foreach (var stmt in functionBody)
        {
            lastReturnValue = Visit(stmt);
        }

        // Pop the function scope off the stack once done
        _hasReturned = false;
        SymbolTable.Pop();
        _functionCallStack.Pop();
        return lastReturnValue;
    }
}