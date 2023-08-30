namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitPostIncDecIdent(FQLParser.PostIncDecIdentContext context)
    {
        var result = VisitPostIncDecStatement(context);
        return result;
    }
}