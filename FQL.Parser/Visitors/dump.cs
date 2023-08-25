namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitDumpStatement(FQLParser.DumpStatementContext context)
    {
        if (context.SYMBOLS() != null)
        {
            _stateManager.SymbolTable.Dump();
        }

        if (context.CALLSTACK() != null)
        {
            DumpCallStack();
        }

        return null;
    }

    public void DumpCallStack()
    {
        var reversedStack = _stateManager.FunctionCallStack.ToArray().Reverse();

        Console.WriteLine("| File                                   | Line   | Function                               |");
        Console.WriteLine("|----------------------------------------|--------|----------------------------------------|");
        foreach (var fn in reversedStack)
        {
            FQLParser.FunctionDefinitionContext context = fn.Value;
            string currentFn = _stateManager.FunctionCallStack.Peek().Key == fn.Key ? "<--" : "   ";

            Console.WriteLine($"| {_stateManager.GrammarName,-38} | {context.Start.Line,6} | {fn.Key,-35}{currentFn} |");
        }
    }
}
