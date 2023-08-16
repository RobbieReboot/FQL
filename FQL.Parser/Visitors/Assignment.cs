namespace FQL.Parser;

public partial class ProgramVisitor
{
    public override object VisitAssignment(FQLParser.AssignmentContext context)
    {
        var name = context.identifier().GetText();
        var value = Visit(context.expression());
        _symbolTable.Add(name, value);

        Console.WriteLine($"new symbol : {name}, value : {value}");

        return null;
    }
}