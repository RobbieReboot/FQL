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

        try
        {
            //var response = await httpClient.GetAsync(url);
            //response.EnsureSuccessStatusCode(); // Throws an exception if the response was not successful
            //var content = await response.Content.ReadAsStringAsync();

            var response = httpClient.GetAsync(url);
            var content = response.Result.Content.ReadAsStringAsync().Result;
            if (response.Result.IsSuccessStatusCode)
            {
                JsonDocument jsonDoc = JsonDocument.Parse(content);
                return jsonDoc;
            }
            else
            {
                throw new HttpRequestException(Utils.CreateError(context, _stateManager.GrammarName,
                    $"Error fetching data from {url}: {response.Result.ReasonPhrase}"));
            }
        }
        //catch (HttpRequestException e)
        //{
        //    throw new HttpRequestException(Utils.CreateError(context, _stateManager.GrammarName,
        //        $"Error fetching data from {url}: {e.Message}"));
        //    return null;
        //}
        catch (Exception e2)
        {
            throw new HttpRequestException(Utils.CreateError(context, _stateManager.GrammarName,
                $"Error fetching data from {url}: {e2.Message}"));
            return null;
        }
    }
}