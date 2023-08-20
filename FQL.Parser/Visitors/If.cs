namespace FQL.Parser;

public partial class ProgramVisitor
{
    public override object VisitIf(FQLParser.IfContext context)
    {
        object result = null;  // Use object or a specific return type if required.
        var leftExpression = Visit(context.expression(0));
        var rightExpression = Visit(context.expression(1));

        // Assuming the Visit method for expressions returns some sort of value,
        // and you can determine equality.
        if (object.Equals(leftExpression, rightExpression))
        {
            result = Visit(context.statements(0));
        }
        else if (context.ELSE() != null)  // if there's an else block
        {
            result = Visit(context.statements(1));
        }
        hasReturned = false;
        return result;
    }

}