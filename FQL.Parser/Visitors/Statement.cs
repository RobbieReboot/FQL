namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitStatement(FQLParser.StatementContext context)
    {
        if (_hasReturned)
        {
            Console.WriteLine($"{StateManager.GrammarName}({context.Start.Line},{context.Start.StartIndex}) : Error FQ0009 : Unreachable code {context.Start.Text}");
        }
        return base.VisitStatement(context);
    }
}