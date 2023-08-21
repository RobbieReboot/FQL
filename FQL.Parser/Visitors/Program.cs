namespace FQL.Parser;

public partial class FQLVisitor
{
    /// <summary>
    /// This is the entry point of the Grammar
    /// </summary>
    /// <param name="context"></param>
    public override object VisitProgram(FQLParser.ProgramContext context)
    {
        foreach (var statement in context.statements().children)
        {
            Visit(statement);
        }

        return null;
    }
}