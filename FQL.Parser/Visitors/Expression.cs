namespace FQL.Parser;

public partial class ProgramVisitor
{
    public override object VisitComplexFactor(FQLParser.ComplexFactorContext context)
    {
        var left = Visit(context.factor());
        var right = Visit(context.expression());
        //            if (context.operator().GetText() == "+")
        return (((int)left) + ((int)right));
    }

    public override object VisitSimpleFactor(FQLParser.SimpleFactorContext context)
    {
        return Visit(context.factor());
    }
}