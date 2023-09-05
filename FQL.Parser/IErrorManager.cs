using Antlr4.Runtime;

namespace FQL.Parser;

public interface IErrorManager
{
    void Debug(ParserRuleContext context, string grammarName, string message);
    void Debug(int l, int c, string grammarName, string message);
    void Info(ParserRuleContext context, string grammarName, string message);
    void Info(int l,int c, string grammarName, string message);
    void Warning(ParserRuleContext context, string grammarName, string message);
    void Warning(int l,int c, string grammarName, string message);
    void Error(ParserRuleContext context, string grammarName, string message);
    void Error(int l,int c, string grammarName, string message);
    void Fatal(ParserRuleContext context, string grammarName, string message);
    void Fatal(int l, int c, string grammarName, string message);
    string Add(FQLError error);
    void Remove(FQLError error);
    void Clear();
    void Show();
    bool HasErrors(FQLErrorSeverity showLevel);
    List<FQLError> Errors { get; }
}