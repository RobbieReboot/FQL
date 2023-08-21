﻿namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitCallStatement(FQLParser.CallStatementContext context)
    {
        string functionName = context.identifier().GetText();

        if (!_functionDefinitions.ContainsKey(functionName))
        {
            throw new Exception($"Undefined function: {functionName}");
        }

        // Create a new scope for the function
        //var functionScope = new Dictionary<string, object>();
        //_scopeStack.Push(functionScope);
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
//            SymbolTable.CurrentScope[parameters[i]] = (string)callingScope[arguments[i].ToString()]!;
            //Add to current scope
            SymbolTable.Add(parameters[i], (string)callingScope[arguments[i].ToString()]!);
        }

        // Now, evaluate the function body
        var functionBody = _functionDefinitions[functionName].statements().children;
        foreach (var stmt in functionBody)
        {
            Visit(stmt);
        }

        // Pop the function scope off the stack once done
        _hasReturned = false;
        SymbolTable.Pop();
//        _scopeStack.Pop();
        return null;
    }
}