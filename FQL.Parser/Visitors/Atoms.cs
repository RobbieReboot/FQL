using System.Text.RegularExpressions;
using FQL.Parser.TypeSystem;

namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitIdent(FQLParser.IdentContext context)
    {
        return _stateManager.SymbolTable[context.ID().GetText()];
    }

    public override object VisitPostIncDecIdent(FQLParser.PostIncDecIdentContext context)
    {
        var result = VisitPostIncDecStatement(context);
        return result;
    }

    public override object VisitIdentifierAtom(FQLParser.IdentifierAtomContext context)
    {
        var result = Visit(context.identifier());       //could be post/pre inc/dec
        return result;
    }

    public override object VisitIntAtom(FQLParser.IntAtomContext context)
    {
        if (int.TryParse(context.i.GetText(), out var result))
            return result; //new IntegerResult(result);

        throw new Exception("Couldn't parse Int Atom.");
    }
  
    public override object VisitFloatAtom(FQLParser.FloatAtomContext context)
    {
        if (double.TryParse(context.f.Text, out var result))
            return result; //new DoubleResult(result);

        throw new Exception("Couldn't parse Int Atom.");
    }

    public override object VisitBoolAtom(FQLParser.BoolAtomContext context)
    {
        var boolVal = Visit(context.boolean()).ToString();
        if (bool.TryParse(boolVal, out var result))
        {
            return result;
        }
        throw new Exception("Couldn't parse Bool Atom.");
    }


    public override object VisitBoolean(FQLParser.BooleanContext context)
    {
        if (context.FALSE() != null)
            //return context.FALSE().ToString();
            return false;
        return true;            //context.TRUE().ToString();
    }

    public override object VisitStringAtom(FQLParser.StringAtomContext context)
    {
        var result = Visit(context.@string());
        return result;
    }

    
    // Complex atoms as opposed to primitives
    public override object VisitFunctionCallAtom(FQLParser.FunctionCallAtomContext context)
    {
        var result = Visit(context.callStatement());
        return result;
    }

    public override object VisitGetAtom(FQLParser.GetAtomContext context)
    {
        var result = Visit(context.getStatement());
        return result;
    }
}