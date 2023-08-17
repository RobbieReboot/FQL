using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System.Text;
using System.Text.RegularExpressions;

namespace FQL.Parser
{
    public partial class ProgramVisitor : FQLParserBaseVisitor<object>
    {
        public static SymbolTable _symbolTable = new SymbolTable();

        public override object VisitProgram(FQLParser.ProgramContext context)
        {
            foreach (var statement in context.statements().children)
            {
                Visit(statement);
            }

            return null;
        }


        // Symbol table to store variables.

        ////public override object VisitCountValue([NotNull] FQLParser.CountValueContext context)
        //{
        //    string tableName = context.STRING().GetText().Trim('"');
        //    // Simulate querying a database
        //    return _database.TryGetValue(tableName, out int count) ? count : 0;
        //}

        public override object VisitConnectionStatement(FQLParser.ConnectionStatementContext context)
        {
            var conStr = Visit(context.@string());
            _symbolTable.Add("connection",conStr);
            return null;
        }
        //public override object VisitConnectionString(FQLParser.ConnectionStringContext context)
        //{
        //    var conStr = context.STRING().GetText();
        //    _symbolTable.Add("ConnectionString", conStr);
        //    Console.WriteLine($"Got COnnection String : {conStr}");
        //    return base.VisitConnectionString(context);
        //}
    }
}