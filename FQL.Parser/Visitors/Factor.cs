using System.Text.RegularExpressions;
using FQL.Parser.TypeSystem;

namespace FQL.Parser;

public partial class ProgramVisitor
{
    public override object VisitIdentifierFactor(FQLParser.IdentifierFactorContext context)
    {
        var identifier = context.id.GetText();
        return _symbolTable[identifier];
    }

    public override object VisitIntFactor(FQLParser.IntFactorContext context)
    {
        if (int.TryParse(context.i.GetText(), out var result))
            return result; //new IntegerResult(result);

        throw new Exception("Couldn't parse Int factor.");
    }
  
    public override object VisitFloatFactor(FQLParser.FloatFactorContext context)
    {
        if (double.TryParse(context.f.Text, out var result))
            return result; //new DoubleResult(result);

        throw new Exception("Couldn't parse Int factor.");
    }

}