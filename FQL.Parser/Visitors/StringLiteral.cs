namespace FQL.Parser;

public partial class ProgramVisitor
{
    public override object VisitStringLiteral(FQLParser.StringLiteralContext context)
    {
        var str = context.STRING().GetText().Trim('"');
        return str;
    }
}