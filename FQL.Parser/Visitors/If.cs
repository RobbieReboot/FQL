namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitIf(FQLParser.IfContext context)
    {
        object result = null!;  // Use object or a specific return type if required.
        var boolResult = (bool)Visit(context.boolExpression());

        // Assuming the Visit method for expressions returns some sort of value,
        // and you can determine equality.
        if (boolResult)
        {
            result = Visit(context.statements(0));
        }
        else if (context.ELSE() != null)  // if there's an else block
        {
            result = Visit(context.statements(1));
        }
        _hasReturned = false;

        // I realize an IF statement shouldn't really return anything, so we can ignore the null ref warning
        // it will be modified before long.
        return result;
    }

}