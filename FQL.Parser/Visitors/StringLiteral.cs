namespace FQL.Parser;

public partial class ProgramVisitor
{
    public override object VisitStrLiteral(FQLParser.StrLiteralContext context)
    {
        var str = context.stringLiteral().GetText().Trim('"');
        return str;
    }
}