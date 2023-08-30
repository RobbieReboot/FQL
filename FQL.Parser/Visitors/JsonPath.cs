using System.CodeDom;
using Antlr4.Runtime.Tree;
using InvalidOperationException = System.InvalidOperationException;

using System.Net.Http;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Policy;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace FQL.Parser;

public partial class FQLVisitor
{
    private readonly JsonElement root;
    public override object VisitJsonPath(FQLParser.JsonPathContext context)
    {
        var firstSegment = context.segment(0);
        var propertyName = firstSegment.ID().GetText();
        var sym = StateManager.SymbolTable[propertyName];
        if (sym == null)
        {
            throw new ArgumentNullException(Utils.CreateError(context, _stateManager.GrammarName,$"{propertyName} does not exist."));
        }

        JsonDocument? jsonDoc = null;

        if (sym is string)
        {
            try
            {
                jsonDoc = JsonDocument.Parse((string)sym);
            }
            catch ( Exception ex)
            {
                throw new ArgumentException(Utils.CreateError(context, _stateManager.GrammarName,
                    $"{propertyName} is not a valid Json fragment. {ex.Message}"));
            }
        }

        if (sym is JsonDocument)                                //probaby came from a get statement
            jsonDoc = sym as JsonDocument;

        if (jsonDoc == null)
            throw new ArgumentException(Utils.CreateError(context, _stateManager.GrammarName,
                $"{propertyName} is not a valid Json fragment."));

        JsonElement current = jsonDoc.RootElement;

        if (firstSegment.INTEGER() != null)
        {
            int index = int.Parse(firstSegment.INTEGER().GetText());
            current = current[index];
        }

        for (int i = 1; i < context.segment().Length; i++)
        {
            var segment = context.segment(i);
            current = VisitSegment(segment, current);
        }

        //convert current to underlying type.
        switch (current.ValueKind)
        {
            //Not supported yet
            case JsonValueKind.Object:
                throw new NotImplementedException("Object Arrays in JSON aren't implemented.");
            case JsonValueKind.Array:
                var result = current.EnumerateArray().Select(o => Utils.ConvertToDynamic(o));
                return result.ToArray();
            case JsonValueKind.String:
                string jsonString = current.GetString();
                return jsonString;
            case JsonValueKind.Number:
                dynamic jsonNumber = Utils.ConvertToDynamic(current);
                return jsonNumber;
            case JsonValueKind.True:
            case JsonValueKind.False:
                bool jsonBoolean = current.GetBoolean();
                return jsonBoolean;
            case JsonValueKind.Null:
                return null;
            default:
                throw new InvalidOperationException("Unexpected JsonValueKind.");
        }
    }

    private JsonElement VisitSegment(FQLParser.SegmentContext context, JsonElement current)
    {
        var propertyName = context.ID().GetText();
        current = current.GetProperty(propertyName);
        if (context.INTEGER() != null)
        {
            int index = int.Parse(context.INTEGER().GetText());
            current = current[index];
        }
        else if (context.STRING() != null)
        {
            var stringIndex = context.STRING().GetText().Trim('"');
            current = current.GetProperty(stringIndex);
        }
        return current;
    }



}