namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitFloatAtom(FQLParser.FloatAtomContext context)
    {
        if (double.TryParse(context.f.Text, out var result))
            return result; //new DoubleResult(result);
        _errorManager.Error(context, _stateManager.GrammarName, "Couldn't parse Float Atom.");
        return null;
        //throw new Exception("Couldn't parse Int Atom.");
    }
}