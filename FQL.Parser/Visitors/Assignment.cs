using System.Text.RegularExpressions;

namespace FQL.Parser;

public partial class FQLVisitor
{

    /// <summary>
    /// var MyVariable = expression
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public override object VisitAssignment(FQLParser.AssignmentContext context)
    {
        var name = context.identifier().GetText();
        object? val = null;
        if (context.expression() != null)
        {
            val = Visit(context.expression());
         }

        if (context.@string() != null)
        {
            val = Visit(context.@string());
            val = Regex.Unescape((string)val);
        }

        if (context.callStatement() != null)
        {
            val = Visit(context.callStatement());
        }

        //if the VAR keyword is tokenised, its a declaration
        if (context.ass != null)
        {
            if (_stateManager.SymbolTable.ExistsInCurrentScope(name))
            {
                _errorManager.Fatal(context, _stateManager.GrammarName, $"Symbol '{name}' already defined.");
            }
            else
            {
                _stateManager.SymbolTable.Add(name, val);
            }

        }
        else
        {
            //otherwise its an assignment
            _stateManager.SymbolTable[name] = val;
        }
        return val;
    }
}