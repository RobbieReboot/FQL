using Antlr4.Runtime;
using FQL.Parser;
using Microsoft.Extensions.DependencyInjection;

namespace FQL.Tests;
[TestClass]
public class JSONAccessTests
{
    private IStateManager _stateManager = null!;
    private IFQLVisitor _visitor =null!;

    [TestInitialize]
    public void Init()
    {
        _stateManager = TestAssemblyInit._serviceProvider.GetService<IStateManager>()!;
    }

    private FQLParser Arrange(string text)
    {
        //Clean out old symbols
        _stateManager.SymbolTable.Clear();
        
        AntlrInputStream inputStream = new AntlrInputStream(text);
        FQLLexer fqlLexer = new FQLLexer(inputStream);
        CommonTokenStream commonTokenStream = new CommonTokenStream(fqlLexer);
        FQLParser fqlParser= new FQLParser(commonTokenStream);
        _visitor = TestAssemblyInit._serviceProvider.GetService<IFQLVisitor>() ?? throw new InvalidOperationException();

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
        _stateManager.SymbolTable.Add("jsonDoc", jsonFQL);
        var result = _visitor!.Visit(context);

        //Note All returns are typed as double by default.
        Assert.AreEqual(result, 38m);
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
        _stateManager.SymbolTable.Add("jsonDoc", jsonFQL);
        var result = _visitor.Visit(context);

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
        var result = _visitor.Visit(context);

        Assert.AreEqual(result,38.0);
    }

    [TestMethod]
    public void AccessArrayAtRootLevelShouldReturnCorrectValue()
    {
        string jsonFQL = """
                         [
                         {
                           "date": "2023-08-27T16:32:31.1886994+00:00",
                           "temperatureC": 38,
                           "temperatureF": 100,
                           "summary": "Freezing"
                         },
                         {
                           "date": "2023-08-28T16:32:31.1887438+00:00",
                           "temperatureC": 49,
                           "temperatureF": 120,
                           "summary": "Scorching"
                         }]
                         """;
        FQLParser parser = Arrange("jsonDoc[1].summary");

        var context = parser.objectAccess();
        _stateManager.SymbolTable.Add("jsonDoc", jsonFQL);
        var result = _visitor.Visit(context);

        //Note All returns are typed as double by default.
        Assert.AreEqual(result, "Scorching");
    }

    [TestMethod]
    public void JsonPath1ShouldReturnCorrectValue()
    {
        string jsonFQL = """
                         [
                         {
                           "date": "2023-08-27T16:32:31.1886994+00:00",
                           "temperatureC": 38,
                           "temperatureF": 100,
                           "summary": "Freezing"
                         },
                         {
                           "date": "2023-08-28T16:32:31.1887438+00:00",
                           "temperatureC": 49,
                           "temperatureF": 120,
                           "summary": "Scorching",
                           "tags" : [
                                "tag v1",
                                "tag v2"
                                ]
                         }]
                         """;
        FQLParser parser = Arrange("jsonDoc[1].tags[1]");

        var context = parser.objectAccess();
        _stateManager.SymbolTable.Add("jsonDoc", jsonFQL);
        var result = _visitor.Visit(context);

        //Note All returns are typed as double by default.
        Assert.AreEqual(result, "tag v2");
    }

    [TestMethod]
    public void PathToArrayShouldReturnCorrectArrayOfTwo()
    {
        string jsonFQL = """
                         [
                         {
                           "date": "2023-08-27T16:32:31.1886994+00:00",
                           "temperatureC": 38,
                           "temperatureF": 100,
                           "summary": "Freezing"
                         },
                         {
                           "date": "2023-08-28T16:32:31.1887438+00:00",
                           "temperatureC": 49,
                           "temperatureF": 120,
                           "summary": "Scorching",
                           "tags" : [
                                26,
                                "tag v2"
                                ]
                         }]
                         """;
        FQLParser parser = Arrange("jsonDoc[1].tags");

        var context = parser.objectAccess();
        _stateManager.SymbolTable.Add("jsonDoc", jsonFQL);
        var result = _visitor.Visit(context);

        //Note All returns are typed as double by default.
        Assert.AreEqual(2,((object[])result).Length);
        Assert.AreEqual(26m,((object[])result)[0]);
        Assert.AreEqual("tag v2",((object[])result)[1] );
    }


    [TestMethod]
    public void BadlyFormattedJsonShouldThrowException()
    {
        //Badly formatted Json
        string jsonFQL = """
                         {
                           date": "2023-08-27T16:32:31.1886994+00:00",
                           XXXXXXX
                         """;
        FQLParser parser = Arrange("jsonDoc[1].tags");

        var context = parser.objectAccess();
        _stateManager.SymbolTable.Add("jsonDoc", jsonFQL);
        var result = _visitor.Visit(context);
        Assert.AreEqual(null, result);
    }


}