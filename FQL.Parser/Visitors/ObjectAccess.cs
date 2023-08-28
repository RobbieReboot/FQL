using Antlr4.Runtime.Tree;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitObjectAccess(FQLParser.ObjectAccessContext context)
    {
        var result = Visit(context.jsonPath());


        return result;
    }

}