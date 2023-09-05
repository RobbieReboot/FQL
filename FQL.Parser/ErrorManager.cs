using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;

namespace FQL.Parser
{
    public class ErrorManager : IErrorManager
    {
        public ErrorManager() { }

        public List<FQLError> Errors { get; } = new(32);

        public void Debug(ParserRuleContext context, string grammarName, string message) =>
            Add(new FQLError(context, grammarName, message, FQLErrorSeverity.Debug));
        public void Debug(int l, int c, string grammarName, string message) =>
            Add(new FQLError(l,c, grammarName, message, FQLErrorSeverity.Debug));

        public void Info(ParserRuleContext context, string grammarName, string message) =>
            Add(new FQLError(context, grammarName, message, FQLErrorSeverity.Info));
        public void Info(int l,int c, string grammarName, string message) =>
            Add(new FQLError(l,c, grammarName, message, FQLErrorSeverity.Info));

        public void Warning(ParserRuleContext context, string grammarName, string message) =>
            Add(new FQLError(context, grammarName, message, FQLErrorSeverity.Warning));
        public void Warning(int l,int c, string grammarName, string message) =>
            Add(new FQLError(l,c, grammarName, message, FQLErrorSeverity.Warning));

        public void Error(ParserRuleContext context, string grammarName, string message) =>
            Add(new FQLError(context, grammarName, message, FQLErrorSeverity.Error));
        public void Error(int l,int c, string grammarName, string message) =>
            Add(new FQLError(l, c, grammarName, message, FQLErrorSeverity.Error));

        public void Fatal(ParserRuleContext context, string grammarName, string message) =>
            Add(new FQLError(context, grammarName, message, FQLErrorSeverity.Fatal));
        public void Fatal(int l, int c, string grammarName, string message) =>
            Add(new FQLError(l, c, grammarName, message, FQLErrorSeverity.Fatal));

        public string Add(FQLError error)
        {
            Errors.Add(error);
            Console.WriteLine(error);
            if (error.Severity is FQLErrorSeverity.Fatal)
            {
                // Halt execution.
                throw new Exception($"HALT: {error.ToString()}");
            }

            return error.CorrelationId.ToString() ?? string.Empty;
        }  
        public void Remove(FQLError error) { Errors.Remove(error); }
        public void Clear() { Errors.Clear(); }

        public void Show()
        {
            foreach (var e in Errors.Where(e=>e.Severity > FQLErrorSeverity.Info))
            {
                Console.WriteLine(e.ToString());
            };
        }

        public bool HasErrors(FQLErrorSeverity showLevel)
        {

            return Errors.Any( e=>e.Severity >= showLevel);
        }
    }
}

