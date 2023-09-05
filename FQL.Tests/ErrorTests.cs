using Antlr4.Runtime;
using FQL.Parser;
using Microsoft.Extensions.DependencyInjection;

namespace FQL.Tests;
[TestClass]
public class ErrorTests
{
    private IStateManager _stateManager = null!;
    private IFQLVisitor _visitor = null!;
    private IErrorManager _errorManager;

    [TestInitialize]
    public void Init()
    {
        _stateManager = TestAssemblyInit._serviceProvider.GetService<IStateManager>()!;
        _errorManager = TestAssemblyInit._serviceProvider.GetService<IErrorManager>();
    }

    private FQLParser Arrange(string text)
    {
        //Clean out old symbols
        _stateManager.SymbolTable.Clear();
        
        AntlrInputStream inputStream = new AntlrInputStream(text);
        FQLLexer fqlLexer = new FQLLexer(inputStream);
        CommonTokenStream commonTokenStream = new CommonTokenStream(fqlLexer);
        FQLParser fqlParser= new FQLParser(commonTokenStream);
        _visitor = TestAssemblyInit._serviceProvider.GetService<IFQLVisitor>()!;

        return fqlParser;
    }
    [TestMethod]
    public void UnknownInterpolationSymbolShouldAddUnknownVariableError()
    {
        FQLParser parser = Arrange("var result = $\"XX{Var1x} YY{Var2}\";");

        var context = parser.assignment();
        var result = _visitor.Visit(context);

        Assert.AreEqual(true, _errorManager.HasErrors(FQLErrorSeverity.Error));
        Assert.AreEqual(true, _errorManager.Errors.Any(e => e.ToString().Contains("Unknown variable 'Var1x'")));
    }
    [TestMethod]
    public void UnknownInterpolationSymbolShouldAddWarningVarIsNull()
    {
        FQLParser parser = Arrange("var result = $\"XX{Var1x} YY{Var2}\";");

        var context = parser.assignment();
        var result = _visitor.Visit(context);

        Assert.AreEqual(true, _errorManager.HasErrors(FQLErrorSeverity.Error));
        Assert.AreEqual(true, _errorManager.Errors.Any(e => e.ToString().Contains("'Var1x' in interpolation string is NULL")));
    }
}