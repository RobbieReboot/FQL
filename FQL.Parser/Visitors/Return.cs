namespace FQL.Parser;

public partial class FQLVisitor
{

    public override object VisitReturnParams(FQLParser.ReturnParamsContext context)
    {
        object? val = null;
        if (context.expression() != null)
        {
            val = Visit(context.expression());
        }
        else
        {
            val = Visit(context.stringLiteral());
        }

        // Prevent processing of further nodes that may override the visitors return value.
        // this should be done as a STACK to preserve the values - we shouldn't really rely on the 
        // visitor returns to relay the return values of a return statement.
        _hasReturned = true;
        //Should push this value on the stack!
        return val;
    }
    //public override 
}