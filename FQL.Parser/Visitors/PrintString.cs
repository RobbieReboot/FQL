namespace FQL.Parser;

public partial class ProgramVisitor
{
    public override object VisitPrintString(FQLParser.PrintStringContext context)
    {
        var str = Visit(context.@string());
        Console.WriteLine(str);
        return null;
    }
}