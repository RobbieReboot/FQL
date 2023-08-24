namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitBreakStatement(FQLParser.BreakStatementContext context)
    {
        if (_stateManager.LoopBreakStack.Count > 0) // Check if inside a loop
        {
            _stateManager.LoopBreakStack.Pop();      // Pop the current loop's false status
            _stateManager.LoopBreakStack.Push(true); // Set the current loop's break status to true
            //Console.WriteLine("Breaking!");
        }
        // else handle error, e.g., a break outside of a loop

        return null;
    }
}