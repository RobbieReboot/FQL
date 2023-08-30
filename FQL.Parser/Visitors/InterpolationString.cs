using System.Text.Json;
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
            if (value is JsonDocument document)
            {
                //pretty printed Json string.
                value = (Utils.PrettyPrintJson(document));
            }

            if (result == true)
            {
                interpolationString = interpolationString.Replace("{" + symbol + "}", value?.ToString());
            }

            else
            {
                throw new ArgumentException(Utils.CreateError(context, _stateManager.GrammarName,
                    $"Unknown variable \"{symbol}\""));
//                throw new ArgumentException($"{_stateManager.GrammarName} ({context.Start.Line},{context.Start.Column}) : Unknown variable \"{symbol}\"");
                // or fail & just show undefined in place of symbol?
                //interpolationString =
                //    interpolationString.Replace("{" + symbol + "}", "{" + $"{symbol} UNDEFINED" + "}");
            }
        }

        return interpolationString.Substring(1).Trim('"');
    }
}