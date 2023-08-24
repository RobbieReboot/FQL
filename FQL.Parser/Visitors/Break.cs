namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitBreakStatement(FQLParser.BreakStatementContext context)
    {
        if (StateManager.loopBreakStack.Count > 0) // Check if inside a loop
        {
            StateManager.loopBreakStack.Pop();      // Pop the current loop's false status
            StateManager.loopBreakStack.Push(true); // Set the current loop's break status to true
            //Console.WriteLine("Breaking!");
        }
        // else handle error, e.g., a break outside of a loop

        return null;
    }
}