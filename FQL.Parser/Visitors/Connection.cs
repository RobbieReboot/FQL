namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitConnectionStatement(FQLParser.ConnectionStatementContext context)
    {
        var conStr = Visit(context.@string());
        _stateManager.SymbolTable.Add("connection", conStr);
        return null;
    }
}