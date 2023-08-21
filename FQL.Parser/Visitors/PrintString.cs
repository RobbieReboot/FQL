namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitPrintString(FQLParser.PrintStringContext context)
    {
        var str = Visit(context.@string());
        Console.WriteLine(str);
        return null;
    }
}