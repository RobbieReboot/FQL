using System.Text.RegularExpressions;

namespace FQL.Parser;

public partial class ProgramVisitor
{
    public override object VisitIdentifierFactor(FQLParser.IdentifierFactorContext context)
    {
        var identifier = context.id.GetText();
        return _symbolTable[identifier];
    }

    public override object VisitStringFactor(FQLParser.StringFactorContext context)
    {
        return Visit(context.str);
        //return context.str.STRING().GetText().Trim('"');
    }

    public override object VisitIntFactor(FQLParser.IntFactorContext context)
    {
        if (Int32.TryParse(context.i.GetText(), out var result))
            return result;

        throw new Exception("Couldn't parse Int factor.");
    }

    public override object VisitParenExpr(FQLParser.ParenExprContext context)
    {
        return Visit(context.expression());
    }



    // string rule alterns


    public override object VisitInterpolationString(FQLParser.InterpolationStringContext context)
    {
        var interpolationString = context.interpolatedString().GetText();


        var interpList = Regex.Matches(interpolationString, @"\{([^}]*)\}")
            .Cast<Match>()
            .Select(m => m.Groups[1].Value)
            .ToArray();

        foreach (var symbol in interpList)
        {
            var result = _symbolTable.TryGetValue(symbol, out object value);
            if (result == true)
            {
                interpolationString = interpolationString.Replace("{" + symbol + "}", value.ToString());
            }
            else
            {
                interpolationString = interpolationString.Replace("{" + symbol + "}", "{"+$"{symbol} UNDEFINED"+"}");
            }
        }

        Console.WriteLine(interpolationString);

        return interpolationString;
    }


    public override object VisitStringLiteral(FQLParser.StringLiteralContext context)
    {
        var str = context.STRING().GetText().Trim('"');
        return str;
    }
}