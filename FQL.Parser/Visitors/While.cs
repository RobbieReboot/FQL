﻿namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitWhileLoop(FQLParser.WhileLoopContext context)
    {
        _stateManager.LoopBreakStack.Push(false);

        // to handle breaks in the middle of a loop, we need to manually iterate across the while loops children

        while ((bool)Visit(context.boolExpression()))
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
        }
        _stateManager.LoopBreakStack.Pop();
        return null;
    }
}