using System.Net.Http;

namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitComplexAtom(FQLParser.ComplexAtomContext context)
    {
        var result = Visit(context.complexAtomPart());
        return result;
    }
}