namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitIdent(FQLParser.IdentContext context)
    {
        var id = context.ID().GetText();
        StateManager.SymbolTable.TryGetValue(id, out object? o);
        if (o == null)
            throw new ArgumentException(
                $"{_stateManager.GrammarName} ({context.Start.Line},{context.Start.Column}) : Unknown variable \"{id}\"");
        return o;
    }
}