namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitDoWhileLoop(FQLParser.DoWhileLoopContext context)
    {
        do
        {
            Visit(context.statements());
        } while ((bool)Visit(context.boolExpression()));

        return null;
    }
}