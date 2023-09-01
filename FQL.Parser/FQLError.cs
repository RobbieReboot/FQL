using System.ComponentModel.DataAnnotations.Schema;
using Antlr4.Runtime;

namespace FQL.Parser;

public class FQLError
{
    private string Error { get; set; }
    private string GrammarName { get;  }
    private string Message { get;  }
    public FQLErrorSeverity Severity { get;  }
    private DateTime ErrorTime { get; } = DateTime.Now;
    public Ulid CorrelationId { get; private set; } = new();
    public int Line { get; set; }
    public int Column { get; set; }
    

    public FQLError(ParserRuleContext context, string grammarName, string message,
        FQLErrorSeverity severity = FQLErrorSeverity.Info)
    {
        Line = context.Start.Line;
        Column = context.Start.Column;
        GrammarName = grammarName;
        Message = message;
        Severity = severity;
    }
    public FQLError(int line,int col, string grammarName, string message,
        FQLErrorSeverity severity = FQLErrorSeverity.Info)
    {
        Line = line;
        Column = col;
        GrammarName = grammarName;
        Message = message;
        Severity = severity;
    }

    public override string ToString() {
        return $"{GrammarName}({Line,3},{Column,-3}): {Severity}: {Message}";
    }
    
}