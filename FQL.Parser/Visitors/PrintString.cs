using System.Text.RegularExpressions;

namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitPrintString(FQLParser.PrintStringContext context)
    {
        var str = Visit(context.@string());
        //Final stage, convert all control sequences.
        str = Regex.Unescape((string)str);
        Console.WriteLine(str);
        return null;
    }
}