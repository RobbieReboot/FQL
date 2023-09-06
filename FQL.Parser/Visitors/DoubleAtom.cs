namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitDoubleAtom(FQLParser.DoubleAtomContext context)
    {
        if (double.TryParse(context.d.Text.TrimEnd(new[] {'d','D'}), out var result))
            return result; //new DoubleResult(result);
        _errorManager.Error(context, _stateManager.GrammarName, "Couldn't parse Double Atom.");
        return null;
    }
}