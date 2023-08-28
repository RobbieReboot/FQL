using System.Text.RegularExpressions;

namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitInterpolationString(FQLParser.InterpolationStringContext context)
    {
        var interpolationString = context.interpolatedString().GetText();


        var interpList = Regex.Matches(interpolationString, @"\{([^}]*)\}")
            .Cast<Match>()
            .Select(m => m.Groups[1].Value)
            .ToArray();

        foreach (var symbol in interpList)
        {
            var result = StateManager.SymbolTable.TryGetValue(symbol, out var value);
            if (result == true)
            {
                interpolationString = interpolationString.Replace("{" + symbol + "}", value?.ToString());
            }
            else
            {
                interpolationString =
                    interpolationString.Replace("{" + symbol + "}", "{" + $"{symbol} UNDEFINED" + "}");
            }
        }

        return interpolationString.Substring(1).Trim('"');
    }
}