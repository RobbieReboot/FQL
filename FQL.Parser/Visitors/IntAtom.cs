namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitIntAtom(FQLParser.IntAtomContext context)
    {
        if (int.TryParse(context.i.GetText(), out var result))
            return result; //new IntegerResult(result);

        throw new Exception("Couldn't parse Int Atom.");
    }
}