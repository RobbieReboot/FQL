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
    public override object VisitJsonPath(FQLParser.JsonPathContext context)
    {
        var firstSegment = context.segment(0);
        var propertyName = firstSegment.ID().GetText();
        var sym = StateManager.SymbolTable[propertyName];
        if (sym == null)
        {
            _errorManager.Error(context, _stateManager.GrammarName, $"'{propertyName}' in Json path is NULL.");
            return null;
        }

        var jsonDoc = sym as JsonDocument;

        if (jsonDoc == null)
        {
            _errorManager.Error(context, _stateManager.GrammarName, $"'{propertyName}' is not a valid Json document.");
            return null;
        }

        JsonElement current = jsonDoc.RootElement;

        if (firstSegment.INTEGER() != null)
        {
            // We're trying to index into a Json Array
            int index = int.Parse(firstSegment.INTEGER().GetText());
            if (current.ValueKind != JsonValueKind.Array)
            {
                _errorManager.Error(context, _stateManager.GrammarName, $"{current} is not an array type.");
                return null;
            }
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
                _errorManager.Error(context, _stateManager.GrammarName, $"Object Arrays in JSON aren't implemented.");
                return null;
            case JsonValueKind.Array:
                var result = current.EnumerateArray().Select(o => Utils.ConvertToDynamic(o))!;
                return result.ToArray();
            case JsonValueKind.String:
                string jsonString = current.GetString()!;
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
                _errorManager.Error(context, _stateManager.GrammarName, $"Unexpected JsonValueKind.");
                return null;
                //throw new InvalidOperationException("Unexpected JsonValueKind.");
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