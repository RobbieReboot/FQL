namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitPrintIdentifier(FQLParser.PrintIdentifierContext context)
    {
        var symbol = context.identifier().GetText();
        var result = _stateManager.SymbolTable.TryGetValue(symbol, out object? value);
        Console.WriteLine(value);
        return null;
    }
}