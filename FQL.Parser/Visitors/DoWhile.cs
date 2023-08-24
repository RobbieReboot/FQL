namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitDoWhileLoop(FQLParser.DoWhileLoopContext context)
    {
        _stateManager.LoopBreakStack.Push(false);

        // to handle breaks in the middle of a loop, we need to manually iterate across the while loops children

        do
        {
            // Manually visit each statement in the loop's block
            foreach (var stmt in context.statements().children)
            {
                Visit(stmt);

                if (_stateManager.LoopBreakStack.Peek()) // Check for break after every statement
                    break;
            }
            if (_stateManager.LoopBreakStack.Peek()) // Check for break after loop's statement block
                break;
        } while ((bool)Visit(context.boolExpression()));

        _stateManager.LoopBreakStack.Pop();
        //do
        //{
        //    Visit(context.statements());
        //} while ((bool)Visit(context.boolExpression()));

        return null;
    }
}