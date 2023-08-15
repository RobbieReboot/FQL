using Antlr4.Runtime.Misc;

namespace FQL.Parser;

public partial class ProgramVisitor
{
    public override object VisitIntLiteral([NotNull] FQLParser.IntLiteralContext context)
    {
        return int.Parse(context.INT().GetText());
    }
}