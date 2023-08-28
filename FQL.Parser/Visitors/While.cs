namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitWhileLoop(FQLParser.WhileLoopContext context)
    {
        StateManager.LoopBreakStack.Push(false);

        // to handle breaks in the middle of a loop, we need to manually iterate across the while loops children

        while ((bool)Visit(context.boolExpression()))
        {
            // Manually visit each statement in the loop's block
            foreach (var stmt in context.statements().children)
            {
                Visit(stmt);

                if (StateManager.LoopBreakStack.Peek()) // Check for break after every statement
                    break;
            }

            if (StateManager.LoopBreakStack.Peek()) // Check for break after loop's statement block
                break;
        }
        StateManager.LoopBreakStack.Pop();
        return null;
    }
}