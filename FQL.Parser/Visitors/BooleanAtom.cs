namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitBoolean(FQLParser.BooleanContext context)
    {
        if (context.FALSE() != null)
            //return context.FALSE().ToString();
            return false;
        return true; //context.TRUE().ToString();
    }
}