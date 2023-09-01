namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitIntAtom(FQLParser.IntAtomContext context)
    {
        if (!int.TryParse(context.i.GetText(), out var result))
        {
            _errorManager.Error(context, _stateManager.GrammarName, "Couldn't parse Int Atom.");
            //throw new Exception("Couldn't parse Int Atom.");
        }
        return result; //new IntegerResult(result);
    }
}