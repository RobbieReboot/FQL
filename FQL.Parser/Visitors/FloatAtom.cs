namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitFloatAtom(FQLParser.FloatAtomContext context)
    {
        if (double.TryParse(context.f.Text, out var result))
            return result; //new DoubleResult(result);

        throw new Exception("Couldn't parse Int Atom.");
    }
}