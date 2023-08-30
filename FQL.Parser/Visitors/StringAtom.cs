namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitStringAtom(FQLParser.StringAtomContext context)
    {
        var result = Visit(context.@string());
        return result;
    }
}