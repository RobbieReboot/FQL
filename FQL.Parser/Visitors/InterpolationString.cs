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
            if (result == false)
            {
                //Symbol doesn't exist.
                _errorManager.Error(context, _stateManager.GrammarName, $"Unknown variable '{symbol}'");
                interpolationString.Replace("{" + symbol + "}", String.Empty);
            }

            //Symbol does exist.
            if (value is JsonDocument document)
            {
                //pretty printed Json string.
                value = (Utils.PrettyPrintJson(document));
            }

            //Variable does exist but contents are null
            if (value!=null && result)
            {
                //Got the symbol 
                interpolationString = interpolationString.Replace("{" + symbol + "}", value?.ToString());
            }

            else
            {
                //Replace the missing variable with an empty string.
                interpolationString = interpolationString.Replace("{" + symbol + "}", String.Empty);
                _errorManager.Warning(context, _stateManager.GrammarName, $"'{symbol}' in interpolation string is NULL");
            }
        }

        return interpolationString.Substring(1).Trim('"');
    }
}