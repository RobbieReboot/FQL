using Antlr4.Runtime;

namespace FQL.Parser;

public class FQLError
{
    private ParserRuleContext Context { get; set; }
    private string Error { get; set; }
    private string GrammarName { get; set; }
    private string Message { get; set; }
    public FQLErrorSeverity Severity { get; set; }
    private DateTime ErrorTime { get; set; }

    public FQLError(ParserRuleContext context, string grammarName, string message,
        FQLErrorSeverity severity = FQLErrorSeverity.Info)
    {
        Context = context;
        GrammarName = grammarName;
        Message = message;
        Severity = severity;
    }

    public override string ToString() {
        return $"{GrammarName}({Context.Start.Line},{Context.Start.Column}): {Severity}: {Message}";
    }
    
}