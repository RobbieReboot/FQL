using Antlr4.Runtime;
using FQL.Parser;
using Microsoft.Extensions.DependencyInjection;

namespace FQL.Tests;
[TestClass]
public class JSONAccessTests
{
    private IStateManager _stateManager = null!;
    [TestInitialize]
    public void Init()
    {
        ServiceManager.BuildServiceProvider();
        _stateManager = ServiceManager.ServiceProvider.GetRequiredService<IStateManager>();
    }

    private FQLParser Arrange(string text)
    {
        //Clean out old symbols
        _stateManager.SymbolTable.Clear();
        
        AntlrInputStream inputStream = new AntlrInputStream(text);
        FQLLexer fqlLexer = new FQLLexer(inputStream);
        CommonTokenStream commonTokenStream = new CommonTokenStream(fqlLexer);
        FQLParser fqlParser= new FQLParser(commonTokenStream);

        return fqlParser;
    }

    [TestMethod]
    public void SingleValueMemberAccessShouldReturnCorrectValue()
    {
        string jsonFQL = """
                         {
                             "date": "2023-08-27T16:32:31.1886994+00:00",
                             "temperatureC": 38,
                             "temperatureF": 100,
                             "summary": "Freezing"
                           }
                         """;
        FQLParser parser = Arrange("jsonDoc.temperatureC");

        var context = parser.objectAccess();
        FQLVisitor visitor = new FQLVisitor();
        _stateManager.SymbolTable.Add("jsonDoc", jsonFQL);
        var result = visitor.Visit(context);

        //Note All returns are typed as double by default.
        Assert.AreEqual(result, 38.0);
    }

    [TestMethod]
    public void StringMemberAccessShouldReturnCorrectValue()
    {
        string jsonFQL = """
                         {
                             "date": "2023-08-27T16:32:31.1886994+00:00",
                             "temperatureC": 38,
                             "temperatureF": 100,
                             "summary": "Freezing"
                           }
                         """;
        FQLParser parser = Arrange("jsonDoc.summary");

        var context = parser.objectAccess();
        FQLVisitor visitor = new FQLVisitor();
        _stateManager.SymbolTable.Add("jsonDoc", jsonFQL);
        var result = visitor.Visit(context);

        //Note All returns are typed as double by default.
        Assert.AreEqual(result, "Freezing");
    }

    
    [TestMethod]
    public void AccessRootLevelShouldReturnCorrectValue()
    {
        string jsonFQL = @"
              var jsonDoc = '{
                ""date"": ""2023-08-27T16:32:31.1886994+00:00"",
                ""temperatureC"": 38,
                ""temperatureF"": 100,
                ""summary"": ""Freezing""
              }';

            var tempC = jsonDoc.temperatureC;
            return tempC;";
        
        FQLParser parser = Arrange(jsonFQL);
        var context = parser.program();
        FQLVisitor visitor = new FQLVisitor();
        var result = visitor.Visit(context);

        Assert.AreEqual(result,38.0);
    }
}