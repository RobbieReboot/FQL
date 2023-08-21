namespace FQL.Parser;

public partial class FQLVisitor
{

    public override object VisitAssignment(FQLParser.AssignmentContext context)
    {
        var name = context.identifier().GetText();
        object? val = null;
        if (context.expression() != null)
        {
            val = Visit(context.expression());
        }
        else
        {
            val = Visit(context.@string());
        }
        SymbolTable.Add(name, val);
        return val;
    }
}