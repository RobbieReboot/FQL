namespace FQL.Parser;

public partial class ProgramVisitor
{
    public override object VisitAssignment(FQLParser.AssignmentContext context)
    {
        var name = context.identifier().GetText();
        object? val = null;
        if (context.expression() != null)
        {
            val = Visit(context.expression());
        }
        else
        {
            val = Visit(context.@string());
        }
        _symbolTable.Add(name, val);

        //Console.WriteLine($"new symbol : {name}, value : {val}");

        return null;
    }
}