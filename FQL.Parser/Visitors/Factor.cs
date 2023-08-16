namespace FQL.Parser;

public partial class ProgramVisitor
{
    public override object VisitIdentifierFactor(FQLParser.IdentifierFactorContext context)
    {
        var identifier = context.id.GetText();
        return _symbolTable[identifier];
    }

    public override object VisitStringFactor(FQLParser.StringFactorContext context)
    {
        return context.str.Text.Trim('"');
    }

    public override object VisitIntFactor(FQLParser.IntFactorContext context)
    {
        if (Int32.TryParse(context.i.GetText(), out var result))
            return result;

        throw new Exception("Couldn't parse Int factor.");
    }

    public override object VisitParenExpr(FQLParser.ParenExprContext context)
    {
        return Visit(context.expression());
    }
}