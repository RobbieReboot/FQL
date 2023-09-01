using System.Text.Json;

namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitPrintIdentifier(FQLParser.PrintIdentifierContext context)
    {
        var symbol = context.identifier().GetText();
        var result = StateManager.SymbolTable.TryGetValue(symbol, out object? value);
        if (value is JsonDocument document)
        {
            //pretty print Json.
            Console.WriteLine(Utils.PrettyPrintJson(document));
        }
        else
        {
            Console.WriteLine(value);
        }
        return null;
    }
}