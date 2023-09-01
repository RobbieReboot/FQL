namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitBoolAtom(FQLParser.BoolAtomContext context)
    {
        var boolVal = Visit(context.boolean()).ToString();
        if (bool.TryParse(boolVal, out var result))
        {
            return result;
        }
        _errorManager.Error(context,_stateManager.GrammarName,"Unable to parse bool.");
        return null;
//        throw new Exception("Couldn't parse Bool Atom.");
    }
}