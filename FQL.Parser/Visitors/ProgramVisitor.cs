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

        //public override object VisitVar([NotNull] FQLParser.VarContext context)
        //{
        //    string varName = context.children[0].GetText();
        //    return _symbolTable.TryGetValue(varName, out object value) ? value : null;
        //}

        //public override object VisitStringLiteral([NotNull] FQLParser.StringLiteralContext context)
        //{
        //    return context.STRING().GetText().Trim('"');
        //}


        //public override object VisitPrintStatement([NotNull] FQLParser.PrintStatementContext context)
        //{
                
        //}

        //public override object VisitPrintInterpolationString(FQLParser.PrintInterpolationStringContext context)
        //{
        //    string interpolatedString = context.STRING_INTERPOLATION().GetText().Trim('$', '"');

        //    var interpList = Regex.Matches(interpolatedString, @"\{([^}]*)\}")
        //        .Cast<Match>()
        //        .Select(m => m.Groups[1].Value)
        //        .ToArray();

        //    foreach (var symbol in interpList)
        //    {
        //        var result = _symbolTable.TryGetValue(symbol, out object value);
        //        if (result == true)
        //        {
        //            interpolatedString = interpolatedString.Replace("{" + symbol + "}", value.ToString());
        //        }
        //    }

        //    Console.WriteLine(interpolatedString);
        //    return base.VisitPrintInterpolationString(context);
        //}

        //public override object VisitPrintStringLiteral(FQLParser.PrintStringLiteralContext context)
        //{
        //    Console.WriteLine(context.STRING().GetText());
        //    return base.VisitPrintStringLiteral(context);
        //}


        //public override object VisitPrintSymbolReference(FQLParser.PrintSymbolReferenceContext context)
        //{
        //    var symbol = context.SYMBOL().GetText();
        //    var result = _symbolTable.TryGetValue(symbol, out object value);
        //    Console.WriteLine(value);
        //    return base.VisitPrintSymbolReference(context);
        //}


        //public override object VisitConnectionString(FQLParser.ConnectionStringContext context)
        //{
        //    var conStr = context.STRING().GetText();
        //    _symbolTable.Add("ConnectionString",conStr);
        //    Console.WriteLine($"Got COnnection String : {conStr}");
        //    return base.VisitConnectionString(context);
        //}
    }
}