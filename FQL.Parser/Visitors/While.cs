namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitWhileLoop(FQLParser.WhileLoopContext context)
    {
        while ((bool)Visit(context.boolExpression()))
        {
            Visit(context.statements());
        }

        return null;
    }
}