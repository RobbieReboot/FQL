using System.Net.Http;
using System.Text.Json;
using Antlr4.Runtime;

namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitGetStatement(FQLParser.GetStatementContext context)
    {
        var url = (string)Visit(context.getParams());
        
        var httpClient = new HttpClient();

        //var response = await httpClient.GetAsync(url);
        //response.EnsureSuccessStatusCode(); // Throws an exception if the response was not successful
        //var content = await response.Content.ReadAsStringAsync();

        var response = httpClient.GetAsync(url);
        var content = response.Result.Content.ReadAsStringAsync().Result;
        if (response.Result.IsSuccessStatusCode)
        {
            //Pre-convert to json document?
            //JsonDocument jsonDoc = JsonDocument.Parse(content);
            //return jsonDoc;

            return content;
        }
        else
        {
            _errorManager.Error(context, _stateManager.GrammarName,$"Unable to fetch data from '{url}' : {response.Result.ReasonPhrase}");
        }

        return null;        //string.Empty;            //no results from the request.
    }
}