using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree.Pattern;


namespace FQL.Parser
{
    public class CustomLexerErrorListener : IAntlrErrorListener<int>
    {
        private readonly IStateManager _stateManager;
        private readonly IErrorManager _errorManager;

        public CustomLexerErrorListener(IStateManager stateManager,IErrorManager err)
        {
            _stateManager = stateManager;
            _errorManager = err;
        }


        public void SyntaxError(TextWriter output, IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine,
            string msg, RecognitionException e)
        {
            // Halts execution.
            _errorManager.Fatal(new ParserRuleContext() { Start = new TokenTagToken("program", 0) { Line = line, Column = charPositionInLine } },
                recognizer.GrammarFileName,$"Syntax error, {msg}");
        }
    }

    public class CustomParserErrorListener : BaseErrorListener
    {
        private readonly IStateManager _stateManager;
        private readonly IErrorManager _errorManager;

        public CustomParserErrorListener(IStateManager stateManager,IErrorManager err)
        {
            _stateManager = stateManager;
            _errorManager = err;
        }

        public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine,
            string msg, RecognitionException e)
        {
            _errorManager.Fatal(line, charPositionInLine , recognizer.GrammarFileName, $"Syntax error, {msg}");
            base.SyntaxError(output, recognizer, offendingSymbol, line, charPositionInLine, msg, e);
        }
    }
}
