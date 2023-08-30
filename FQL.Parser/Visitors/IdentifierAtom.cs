namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitIdentifierAtom(FQLParser.IdentifierAtomContext context)
    {
        var result = Visit(context.identifier()); //could be post/pre inc/dec
        return result;
    }
}