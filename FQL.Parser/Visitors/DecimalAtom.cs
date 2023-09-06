namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitDecimalAtom(FQLParser.DecimalAtomContext context)
    {
        if (decimal.TryParse(context.m.Text.TrimEnd(new []{'m','M'}), out var result))
            return result; //new DoubleResult(result);
        _errorManager.Error(context, _stateManager.GrammarName, "Couldn't parse DecimalAtom.");
        return null;
    }
}