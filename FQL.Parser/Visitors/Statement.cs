namespace FQL.Parser;

public partial class ProgramVisitor
{
    public override object VisitStatement(FQLParser.StatementContext context)
    {
        if (hasReturned)
        {
            Console.WriteLine($"{this.GrammarName}({context.Start.Line},{context.Start.StartIndex}) : Error FQ0009 : Unreachable code {context.Start.Text}");
        }
        return base.VisitStatement(context);
    }
}