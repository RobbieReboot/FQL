namespace FQL.Parser;

public partial class ProgramVisitor
{
    public override object VisitPrintIdentifier(FQLParser.PrintIdentifierContext context)
    {
        var symbol = context.identifier().GetText();
        var result = _symbolTable.TryGetValue(symbol, out object value);
        Console.WriteLine(value);
        return null;
    }
}