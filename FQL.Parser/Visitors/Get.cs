using System.Net.Http;
using System.Text.Json;

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

            JsonDocument jsonDoc = JsonDocument.Parse(content);

            return jsonDoc;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Error fetching data from {url}: {e.Message}");
            return null;
        }
    }
}