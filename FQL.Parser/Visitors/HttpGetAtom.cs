namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitGetAtom(FQLParser.GetAtomContext context)
    {
        var result = Visit(context.getStatement());
        return result;
    }
}