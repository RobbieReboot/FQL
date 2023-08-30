namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitFunctionCallAtom(FQLParser.FunctionCallAtomContext context)
    {
        var result = Visit(context.callStatement());
        return result;
    }
}