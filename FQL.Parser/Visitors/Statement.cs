using System.Security.Policy;

namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitStatement(FQLParser.StatementContext context)
    {
        if (_hasReturned)
        {
            _errorManager.Warning(context, _stateManager.GrammarName, $"possibly unreachable code {context.Start.Text}");
        }
        return base.VisitStatement(context);
    }
}