namespace FQL.Parser;

public partial class ProgramVisitor
{

    public override object VisitReturnParams(FQLParser.ReturnParamsContext context)
    {
        Console.WriteLine($"return VISITOR ENTRY: children ( {context.children.Count} )");
        object? val = null;
        if (context.expression() != null)
        {
            val = Visit(context.expression());
        }
        else
        {
            val = Visit(context.stringLiteral());
        }

        //Should push this value on the stack!
        hasReturned = true;
        return val;
    }
    //public override 
}