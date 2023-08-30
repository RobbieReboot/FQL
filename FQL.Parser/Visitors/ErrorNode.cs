using Antlr4.Runtime.Tree;
using System.Net.Http;

namespace FQL.Parser;

public partial class FQLVisitor
{
    public override object VisitErrorNode(IErrorNode node)
    {
        int line = node.Symbol.Line;
        int charPositionInLine = node.Symbol.Column;
        Console.WriteLine($"{_stateManager.GrammarName} ({line},{charPositionInLine}) : Syntax error: {node.GetText()}");
        return base.VisitErrorNode(node);
    }
}