namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitBreakStatement(FQLParser.BreakStatementContext context)
    {
        if (StateManager.LoopBreakStack.Count > 0) // Check if inside a loop
        {
            StateManager.LoopBreakStack.Pop();      // Pop the current loop's false status
            StateManager.LoopBreakStack.Push(true); // Set the current loop's break status to true
            //Console.WriteLine("Breaking!");
        }
        // else handle error, e.g., a break outside of a loop

        return null;
    }
}