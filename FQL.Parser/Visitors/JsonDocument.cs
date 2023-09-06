using System.Text.Json;

namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitJsonDocument(FQLParser.JsonDocumentContext context)
    {
        // Extract a Json document from a string.

        var txt = context.GetText();
        try
        {
            var jsonDoc = JsonDocument.Parse(txt.Trim(new[] { '@', '"' }),
                new JsonDocumentOptions() { AllowTrailingCommas = true, MaxDepth = 8 });
            return jsonDoc;
        }
        catch (Exception ex)
        {
            _errorManager.Error(context, _stateManager.GrammarName, $"Malformed Json Document. {ex.Message}");
            return null;
        }
    }
}