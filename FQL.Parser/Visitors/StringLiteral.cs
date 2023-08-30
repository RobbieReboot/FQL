using System.Text.RegularExpressions;

namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitStrLiteral(FQLParser.StrLiteralContext context)
    {
        var str = context.stringLiteral().GetText().Trim('"').Trim('\'');
        str = Regex.Unescape((string)str);
        return str;
    }
}