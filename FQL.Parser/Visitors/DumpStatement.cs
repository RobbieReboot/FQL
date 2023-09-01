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
           _stateManager.DumpCallStack();
        }

        return null;
    }

}
