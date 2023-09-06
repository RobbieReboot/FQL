using Antlr4.Runtime.Tree;
using FQL.Parser.TypeSystem;

namespace FQL.Parser;

/// <summary>
/// All the visitors that make up the Expression evaluator part of the parser.
/// </summary>
/// <remarks>
/// True recursive descent that honours the operator order of precedence.
/// </remarks>
public partial class FQLVisitor
{
    public override object VisitAdditiveExpr(FQLParser.AdditiveExprContext context)
    {
        var r = Visit(context.mulDivExpr(0));
        if (!Utils.IsNumericTypeBasedOnRefValueType(r))
            return r;

        dynamic result = r;

        for (int i = 1; i < context.mulDivExpr().Length; i++)
        {
            if (context.GetChild(i * 2 - 1).GetText() == "+")
            {
                result +=(dynamic) Visit(context.mulDivExpr(i));
            }
            else
                result -= (dynamic)Visit(context.mulDivExpr(i));
        }
        return result;
    }

    public override object VisitMultiplicativeExpr(FQLParser.MultiplicativeExprContext context)
    {
        var r = Visit(context.powExpr(0));
        //if its NOT numeric, return it up the chain.
        if (!Utils.IsNumericTypeBasedOnRefValueType(r))
            return r;
        //if (r is bool || r is string)
        //    return r;

        dynamic result = r;
        for (int i = 1; i < context.powExpr().Length; i++)
        {
            if (context.GetChild(i * 2 - 1).GetText() == "*")
                result *= (dynamic)Visit(context.powExpr(i));
            else
                result /= (dynamic)Visit(context.powExpr(i));
        }
        return result;
    }

    public override object VisitExponentationExpr(FQLParser.ExponentationExprContext context)
    {
        if (context.CARET() != null)            // only do the exponent IF there is an exponent to raise the power to!
            return Math.Pow((dynamic)Visit(context.atom()),(dynamic) Visit(context.powExpr()));
        return Visit(context.atom());
    }

    public override object  VisitParenExpr(FQLParser.ParenExprContext context)
    {
        var r = (dynamic)Visit(context.expression());
        //if its NOT numeric, return it up the chain.
        if (!Utils.IsNumericTypeBasedOnRefValueType(r))
            return r;
        return r;
    }


}