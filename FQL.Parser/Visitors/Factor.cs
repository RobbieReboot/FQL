using System.Text.RegularExpressions;
using FQL.Parser.TypeSystem;

namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitIdentifierFactor(FQLParser.IdentifierFactorContext context)
    {
        var identifier = context.id.GetText();
        return SymbolTable[identifier];
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

    public override object VisitBoolFactor(FQLParser.BoolFactorContext context)
    {
        var boolVal = Visit(context.boolean()).ToString();
        if (bool.TryParse(boolVal, out var result))
        {
            return result;
        }
        throw new Exception("Couldn't parse Bool factor.");
    }


    public override object VisitBoolean(FQLParser.BooleanContext context)
    {
        if (context.FALSE() != null)
            //return context.FALSE().ToString();
            return false;
        return true;            //context.TRUE().ToString();
    }
}