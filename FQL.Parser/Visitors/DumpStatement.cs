﻿namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitDumpStatement(FQLParser.DumpStatementContext context)
    {
        if (context.SYMBOLS() != null)
        {
            StateManager.SymbolTable.Dump();
        }

        if (context.CALLSTACK() != null)
        {
            DumpCallStack();
        }

        return null;
    }

    public void DumpCallStack()
    {
        var reversedStack = StateManager.FunctionCallStack.ToArray().Reverse();

        Console.WriteLine("| File                                   | Line   | Function                               |");
        Console.WriteLine("|----------------------------------------|--------|----------------------------------------|");
        foreach (var fn in reversedStack)
        {
            FQLParser.FunctionDefinitionContext context = fn.Value;
            string currentFn = StateManager.FunctionCallStack.Peek().Key == fn.Key ? "<--" : "   ";

            Console.WriteLine($"| {StateManager.GrammarName,-38} | {context.Start.Line,6} | {fn.Key,-35}{currentFn} |");
        }
    }
}