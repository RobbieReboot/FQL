namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitDumpStatement(FQLParser.DumpStatementContext context)
    {
        if (context.SYMBOLS() != null)
        {
            SymbolTable.Dump();
        }

        if (context.CALLSTACK() != null)
        {
            DumpCallStack();
        }

        return null;
    }

    public void DumpCallStack()
    {
        var reversedStack = _functionCallStack.ToArray().Reverse();
        Console.WriteLine("| Line   | Function                               |");
//        Console.WriteLine("|--------|---------------------------------------|");
        Console.WriteLine("|--------|----------------------------------------|");
        foreach (var fn in reversedStack)
        {
            FQLParser.FunctionDefinitionContext context = fn.Value;
            Console.WriteLine($"| {context.Start.Line,6} | {fn.Key,38} |");
        }
    }
}
