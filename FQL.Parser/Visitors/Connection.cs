namespace FQL.Parser;

public partial class ProgramVisitor
{
    public override object VisitConnectionStatement(FQLParser.ConnectionStatementContext context)
    {
        var conStr = Visit(context.@string());
        _symbolTable.Add("connection", conStr);
        return null;
    }
}