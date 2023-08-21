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

        if (context.@string()!=null)
        {
            val = Visit(context.@string());
        }

        if (context.callStatement() != null)
        {
            val = Visit(context.callStatement());
        }
        SymbolTable.Add(name, val);
        return val;
    }
}