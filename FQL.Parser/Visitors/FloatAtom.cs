namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitFloatAtom(FQLParser.FloatAtomContext context)
    {
        if (float.TryParse(context.f.Text.TrimEnd(new []{'f','F'}), out var result))
            return result; //new DoubleResult(result);
        _errorManager.Error(context, _stateManager.GrammarName, "Couldn't parse Float Atom.");
        return null;
        //throw new Exception("Couldn't parse Int Atom.");
    }
}