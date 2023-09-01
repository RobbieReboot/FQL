namespace FQL.Parser;

public partial class FQLVisitor
{
    /// <summary>
    /// This is the entry point of the Grammar
    /// </summary>
    /// <param name="context"></param>
    public override object VisitProgram(FQLParser.ProgramContext context)
    {

        object? lastResult = null;
        foreach (var statement in context.statements().children)
        {
            lastResult = Visit(statement);
            if (_hasReturned)
                break;                  //Return from global scope!
        }

        return lastResult;
    }
}