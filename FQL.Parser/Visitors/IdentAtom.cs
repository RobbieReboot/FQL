namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitIdent(FQLParser.IdentContext context)
    {
        var id = context.ID().GetText();
        StateManager.SymbolTable.TryGetValue(id, out object? o);
        if (o == null)
        {
            _errorManager.Error(context, _stateManager.GrammarName, $"{id} is undefined.");
            return null;
        }

        return o;
    }
}