namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitFunctionDefinition(FQLParser.FunctionDefinitionContext context)
    {
        string functionName = context.identifier().GetText();
        StateManager.FunctionDefinitions[functionName] = context;

        var parameters = context.paramList()?.identifier().Select(param => param.GetText()).ToList() ?? new List<string>();
        StateManager.FunctionParameters[functionName] = parameters;
        return null;
    }
}