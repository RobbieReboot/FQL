using Antlr4.Runtime.Misc;

namespace FQL.Parser;

public partial class ProgramVisitor
{
    //public override object VisitVarDeclaration([NotNull] FQLParser.VarDeclarationContext context)
    //{
    //    string varName = context.SYMBOL().GetText();
    //    object value = Visit(context.expression());

    //    _symbolTable[varName] = value;
    //    return null;
    //}
}