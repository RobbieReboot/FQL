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

        // Map passed arguments contexts to function parameters after visiting the context nodes
        var arguments = context.callParamList().expression().Select(arg => arg).ToList();
        var parameters = _functionParameters[functionName];

        if (arguments.Count != parameters.Count)
        {
            throw new Exception($"Function {functionName} expects {parameters.Count} parameters but got {arguments.Count}.");
        }

        // Accumulate variables that will be visible inside the function scope
        Dictionary<string, object?> functionScope = new Dictionary<string, object?>();

        for (int i = 0; i < arguments.Count; i++)
        {
            // Parse the caller's arguments & copy their contents to new vars in function scope.
            var result = Visit(arguments[i]);
            // Add to current scope - EMULATE PASS BY VALUE!
            functionScope.Add(parameters[i], result);
        }

        SymbolTable.Push(functionScope);
        // Now, evaluate the function body
        var functionBody = _functionDefinitions[functionName].statements().children;
        object? lastReturnValue = null;
        foreach (var stmt in functionBody)
        {
            lastReturnValue = Visit(stmt);
        }

        // Pop the function scope & call stack entry off the stack once done
        _hasReturned = false;
        SymbolTable.Pop();
        _functionCallStack.Pop();
        return lastReturnValue;
    }
}