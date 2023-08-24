using System.Reflection;
using Antlr4.Runtime;
using FQL.Parser;

namespace FQL.Tests;
[TestClass]
public class BooleanLogicTests
{
    private SymbolTable SymbolTable => StateManager.SymbolTable;

    private FQLParser Arrange(string text)
    {
        //Clean out old symbols
        SymbolTable.Clear();
        
        AntlrInputStream inputStream = new AntlrInputStream(text);
        FQLLexer fqlLexer = new FQLLexer(inputStream);
        CommonTokenStream commonTokenStream = new CommonTokenStream(fqlLexer);
        FQLParser fqlParser= new FQLParser(commonTokenStream);

        return fqlParser;
    }

   public static IEnumerable<object[]> BooleanTestData
    {
        get
        {
            return new[]
            {

                new object[] { "1 == 1", true,"Numeric equality" },
                new object[] { "1 == 2",false, "Numeric equality - negative" },
                
                new object[] { "5 != 4", true, "Numeric inequality" },
                new object[] { "5 != 5", false, "Numeric inequality - negative" },

                new object[] { "5 > 4", true, "Numeric greater than" },
                new object[] { "4 > 5", false, "Numeric greater than- negative" },
                new object[] { "5 >= 4", true, "Numeric greater than or equal" },
                new object[] { "5 >= 5", true, "Numeric greater than or equal (equal)" },
                new object[] { "4 >= 5", false, "Numeric greater than or equal - negative" },

                new object[] { "4 < 5", true, "Numeric less than" },
                new object[] { "5 < 4", false, "Numeric less than - negative" },
                new object[] { "4 <= 5", true, "Numeric less than or equal" },
                new object[] { "5 <= 5", true, "Numeric less than or equal (equal)" },
                new object[] { "5 <= 4", false, "Numeric less than or equal - negative" },

                // String tests
                new object[] { "\"ABC\"==\"ABC\"", true, "String equality" },
                new object[] { "\"ABC\"==\"CBA\"", false, "String equality - negative" },

                new object[] { "\"ABC\"!=\"CBA\"", true, "String inequality" },
                new object[] { "\"ABC\"!=\"ABC\"", false, "String inequality - negative" },

                new object[] { "\"A\" < \"B\"", true, "String less than" },
                new object[] { "\"B\" < \"A\"", false, "String less than - negative" },
                new object[] { "\"A\" <= \"A\"", true , "String less than or equal (equal)" },
                new object[] { "\"A\" <= \"B\"", true , "String less than or equal " },
                new object[] { "\"B\" <= \"A\"", false , "String less than or equal - negative" },

                new object[] { "\"B\" > \"A\"", true , "String greater than" },
                new object[] { "\"A\" > \"B\"", false , "String greater than - negative" },
                new object[] { "\"A\" >= \"A\"", true , "String greater than or equal (equal)" },
                new object[] { "\"B\" >= \"A\"", true , "String greater than or equal" },
                new object[] { "\"A\" >= \"B\"", false , "String greater than or equal - negative" },
            };
        }
    }

    // Function to provide test description
    public static string GetCustomDynamicDataDisplayName(MethodInfo methodInfo, object[] data)
    {
        return (string)data[2];
    }

    [TestMethod]
    [DynamicData(nameof(BooleanTestData), DynamicDataDisplayName = nameof(GetCustomDynamicDataDisplayName))]
    public void BoolLogicTestsShouldReturnCorrectResult(string input,bool expectedResult,string name)
    {
        FQLParser parser = Arrange(input);

        var context = parser.boolExpression();
        FQLVisitor visitor = new FQLVisitor();
        var actual= visitor.Visit(context);

        Assert.AreEqual(actual, expectedResult);
    }
}