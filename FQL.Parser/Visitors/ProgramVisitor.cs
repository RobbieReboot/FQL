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
    }
}