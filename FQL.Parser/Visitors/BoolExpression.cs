namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitBoolExpression(FQLParser.BoolExpressionContext context)
    {
        bool result = (bool)Visit(context.boolTerm(0));

        for (int i = 1; i < context.boolTerm().Length; i++)
        {
            result = result || (bool)Visit(context.boolTerm(i));
        }

        return result;
    }

    // boolTerm: AND operation
    public override object VisitBoolTerm(FQLParser.BoolTermContext context)
    {
        bool result = (bool)Visit(context.boolFactor(0));

        for (int i = 1; i < context.boolFactor().Length; i++)
        {
            result = result && (bool)Visit(context.boolFactor(i));
        }

        return result;
    }

    // boolFactor: NOT operation, relational operations, etc.
    public override object VisitBoolFactor(FQLParser.BoolFactorContext context)
    {
        if (context.relationalExpr() != null)
            return Visit(context.relationalExpr());
        if (context.BANG() != null)
            return !(bool)Visit(context.boolFactor());
        if (context.boolLiteral() != null)
            return Visit(context.boolLiteral());
        return Visit(context.boolExpression());  // for (boolExpression) case
    }

    public override object VisitBoolLiteral(FQLParser.BoolLiteralContext context)
    {
        if (context.TRUE() != null)
            return true;
        if (context.FALSE() != null)
            return false;
        _errorManager.Error(context, _stateManager.GrammarName, "Unexpected bool literal.");
        return null;
        //throw new InvalidOperationException("Unexpected boolLiteral value");
    }

    public override object VisitRelationalExpr(FQLParser.RelationalExprContext context)
    {
        var left = Visit(context.expression(0));
        var right = Visit(context.expression(1));
        var op = context.REL_OP().GetText();


        if (left is string leftStr && right is string rightStr)
        {
            int result = String.CompareOrdinal(leftStr, rightStr);

            switch (op)
            {
                case "==": return result == 0;
                case "!=": return result != 0;
                case "<":  return result < 0;
                case "<=": return result <= 0;
                case ">": return result > 0;
                case ">=": return result >= 0;
                default:
                    _errorManager.Error(context, _stateManager.GrammarName, $"Unsupported string comparison operation {op}.");
                    return null;
                    //throw new InvalidOperationException(
                        //$"{StateManager.GrammarName}({context.Start.Line}) : Unsupported string comparison operation {op}");
            }

        }
        else if (left is IComparable leftComp && right is IComparable rightComp)
        {
            int result = leftComp.CompareTo(rightComp);
            switch (op)
            {
                case "==": return result == 0;
                case "!=": return result != 0;
                case "<": return result < 0;
                case "<=": return result <= 0;
                case ">": return result > 0;
                case ">=": return result >= 0;
                default:
                    _errorManager.Error(context, _stateManager.GrammarName, $"Unsupported string comparison operation {op}.");
                    return null;
                    //throw new InvalidOperationException($"Unsupported operation: {op}");
            }
        }
        else
        {
            _errorManager.Error(context, _stateManager.GrammarName, $"type mismatch in relational expression '{op}' (or no IComparable implementations).");
            //throw new InvalidOperationException($"{StateManager.GrammarName}({context.Start.Line}) : type mismatch in relational expression '{op}' (or no IComparable implementations).");
        }

        return null;
    }
}