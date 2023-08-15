//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\projects\Chevin\Sandbox\FQL\FQL.Parser\FQLParser.g4 by ANTLR 4.13.0

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace FQL.Parser {
using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.0")]
[System.CLSCompliant(false)]
public partial class FQLParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		SINGLE_LINE_COMMENT=1, VAR=2, PRINT=3, CONNECTION=4, EQUALS=5, SEMI=6, 
		LPAREN=7, RPAREN=8, COUNT=9, LCURLY=10, RCURLY=11, INT=12, MULTI_LINE_COMMENT=13, 
		SYMBOL=14, STRING=15, STRING_INTERPOLATION=16, ESC=17, WS=18;
	public const int
		RULE_program = 0, RULE_statement = 1, RULE_varDeclaration = 2, RULE_expression = 3, 
		RULE_printStatement = 4, RULE_printParams = 5, RULE_connectionString = 6;
	public static readonly string[] ruleNames = {
		"program", "statement", "varDeclaration", "expression", "printStatement", 
		"printParams", "connectionString"
	};

	private static readonly string[] _LiteralNames = {
		null, null, "'VAR'", "'PRINT'", "'CONNECTION'", "'='", "';'", "'('", "')'", 
		"'COUNT'", "'{'", "'}'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "SINGLE_LINE_COMMENT", "VAR", "PRINT", "CONNECTION", "EQUALS", "SEMI", 
		"LPAREN", "RPAREN", "COUNT", "LCURLY", "RCURLY", "INT", "MULTI_LINE_COMMENT", 
		"SYMBOL", "STRING", "STRING_INTERPOLATION", "ESC", "WS"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "FQLParser.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static FQLParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public FQLParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public FQLParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class ProgramContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode Eof() { return GetToken(FQLParser.Eof, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public StatementContext[] statement() {
			return GetRuleContexts<StatementContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public StatementContext statement(int i) {
			return GetRuleContext<StatementContext>(i);
		}
		public ProgramContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_program; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IFQLParserVisitor<TResult> typedVisitor = visitor as IFQLParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitProgram(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ProgramContext program() {
		ProgramContext _localctx = new ProgramContext(Context, State);
		EnterRule(_localctx, 0, RULE_program);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 17;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & 8222L) != 0)) {
				{
				{
				State = 14;
				statement();
				}
				}
				State = 19;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			State = 20;
			Match(Eof);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class StatementContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public VarDeclarationContext varDeclaration() {
			return GetRuleContext<VarDeclarationContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public PrintStatementContext printStatement() {
			return GetRuleContext<PrintStatementContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ConnectionStringContext connectionString() {
			return GetRuleContext<ConnectionStringContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode SINGLE_LINE_COMMENT() { return GetToken(FQLParser.SINGLE_LINE_COMMENT, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode MULTI_LINE_COMMENT() { return GetToken(FQLParser.MULTI_LINE_COMMENT, 0); }
		public StatementContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_statement; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IFQLParserVisitor<TResult> typedVisitor = visitor as IFQLParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitStatement(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public StatementContext statement() {
		StatementContext _localctx = new StatementContext(Context, State);
		EnterRule(_localctx, 2, RULE_statement);
		try {
			State = 27;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case VAR:
				EnterOuterAlt(_localctx, 1);
				{
				State = 22;
				varDeclaration();
				}
				break;
			case PRINT:
				EnterOuterAlt(_localctx, 2);
				{
				State = 23;
				printStatement();
				}
				break;
			case CONNECTION:
				EnterOuterAlt(_localctx, 3);
				{
				State = 24;
				connectionString();
				}
				break;
			case SINGLE_LINE_COMMENT:
				EnterOuterAlt(_localctx, 4);
				{
				State = 25;
				Match(SINGLE_LINE_COMMENT);
				}
				break;
			case MULTI_LINE_COMMENT:
				EnterOuterAlt(_localctx, 5);
				{
				State = 26;
				Match(MULTI_LINE_COMMENT);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class VarDeclarationContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode VAR() { return GetToken(FQLParser.VAR, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode SYMBOL() { return GetToken(FQLParser.SYMBOL, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode EQUALS() { return GetToken(FQLParser.EQUALS, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ExpressionContext expression() {
			return GetRuleContext<ExpressionContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode SEMI() { return GetToken(FQLParser.SEMI, 0); }
		public VarDeclarationContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_varDeclaration; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IFQLParserVisitor<TResult> typedVisitor = visitor as IFQLParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitVarDeclaration(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public VarDeclarationContext varDeclaration() {
		VarDeclarationContext _localctx = new VarDeclarationContext(Context, State);
		EnterRule(_localctx, 4, RULE_varDeclaration);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 29;
			Match(VAR);
			State = 30;
			Match(SYMBOL);
			State = 31;
			Match(EQUALS);
			State = 32;
			expression();
			State = 33;
			Match(SEMI);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ExpressionContext : ParserRuleContext {
		public ExpressionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_expression; } }
	 
		public ExpressionContext() { }
		public virtual void CopyFrom(ExpressionContext context) {
			base.CopyFrom(context);
		}
	}
	public partial class StringLiteralContext : ExpressionContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode STRING() { return GetToken(FQLParser.STRING, 0); }
		public StringLiteralContext(ExpressionContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IFQLParserVisitor<TResult> typedVisitor = visitor as IFQLParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitStringLiteral(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class VarContext : ExpressionContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode SYMBOL() { return GetToken(FQLParser.SYMBOL, 0); }
		public VarContext(ExpressionContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IFQLParserVisitor<TResult> typedVisitor = visitor as IFQLParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitVar(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class IntLiteralContext : ExpressionContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode INT() { return GetToken(FQLParser.INT, 0); }
		public IntLiteralContext(ExpressionContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IFQLParserVisitor<TResult> typedVisitor = visitor as IFQLParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitIntLiteral(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ExpressionContext expression() {
		ExpressionContext _localctx = new ExpressionContext(Context, State);
		EnterRule(_localctx, 6, RULE_expression);
		try {
			State = 38;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case STRING:
				_localctx = new StringLiteralContext(_localctx);
				EnterOuterAlt(_localctx, 1);
				{
				State = 35;
				Match(STRING);
				}
				break;
			case INT:
				_localctx = new IntLiteralContext(_localctx);
				EnterOuterAlt(_localctx, 2);
				{
				State = 36;
				Match(INT);
				}
				break;
			case SYMBOL:
				_localctx = new VarContext(_localctx);
				EnterOuterAlt(_localctx, 3);
				{
				State = 37;
				Match(SYMBOL);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class PrintStatementContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode PRINT() { return GetToken(FQLParser.PRINT, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public PrintParamsContext printParams() {
			return GetRuleContext<PrintParamsContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode SEMI() { return GetToken(FQLParser.SEMI, 0); }
		public PrintStatementContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_printStatement; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IFQLParserVisitor<TResult> typedVisitor = visitor as IFQLParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitPrintStatement(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public PrintStatementContext printStatement() {
		PrintStatementContext _localctx = new PrintStatementContext(Context, State);
		EnterRule(_localctx, 8, RULE_printStatement);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 40;
			Match(PRINT);
			State = 41;
			printParams();
			State = 42;
			Match(SEMI);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class PrintParamsContext : ParserRuleContext {
		public PrintParamsContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_printParams; } }
	 
		public PrintParamsContext() { }
		public virtual void CopyFrom(PrintParamsContext context) {
			base.CopyFrom(context);
		}
	}
	public partial class PrintInterpolationStringContext : PrintParamsContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode STRING_INTERPOLATION() { return GetToken(FQLParser.STRING_INTERPOLATION, 0); }
		public PrintInterpolationStringContext(PrintParamsContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IFQLParserVisitor<TResult> typedVisitor = visitor as IFQLParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitPrintInterpolationString(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class PrintSymbolReferenceContext : PrintParamsContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode SYMBOL() { return GetToken(FQLParser.SYMBOL, 0); }
		public PrintSymbolReferenceContext(PrintParamsContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IFQLParserVisitor<TResult> typedVisitor = visitor as IFQLParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitPrintSymbolReference(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class PrintStringLiteralContext : PrintParamsContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode STRING() { return GetToken(FQLParser.STRING, 0); }
		public PrintStringLiteralContext(PrintParamsContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IFQLParserVisitor<TResult> typedVisitor = visitor as IFQLParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitPrintStringLiteral(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public PrintParamsContext printParams() {
		PrintParamsContext _localctx = new PrintParamsContext(Context, State);
		EnterRule(_localctx, 10, RULE_printParams);
		try {
			State = 47;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case STRING_INTERPOLATION:
				_localctx = new PrintInterpolationStringContext(_localctx);
				EnterOuterAlt(_localctx, 1);
				{
				State = 44;
				Match(STRING_INTERPOLATION);
				}
				break;
			case STRING:
				_localctx = new PrintStringLiteralContext(_localctx);
				EnterOuterAlt(_localctx, 2);
				{
				State = 45;
				Match(STRING);
				}
				break;
			case SYMBOL:
				_localctx = new PrintSymbolReferenceContext(_localctx);
				EnterOuterAlt(_localctx, 3);
				{
				State = 46;
				Match(SYMBOL);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ConnectionStringContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode CONNECTION() { return GetToken(FQLParser.CONNECTION, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode STRING() { return GetToken(FQLParser.STRING, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode SEMI() { return GetToken(FQLParser.SEMI, 0); }
		public ConnectionStringContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_connectionString; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IFQLParserVisitor<TResult> typedVisitor = visitor as IFQLParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitConnectionString(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ConnectionStringContext connectionString() {
		ConnectionStringContext _localctx = new ConnectionStringContext(Context, State);
		EnterRule(_localctx, 12, RULE_connectionString);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 49;
			Match(CONNECTION);
			State = 50;
			Match(STRING);
			State = 51;
			Match(SEMI);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	private static int[] _serializedATN = {
		4,1,18,54,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,6,1,0,
		5,0,16,8,0,10,0,12,0,19,9,0,1,0,1,0,1,1,1,1,1,1,1,1,1,1,3,1,28,8,1,1,2,
		1,2,1,2,1,2,1,2,1,2,1,3,1,3,1,3,3,3,39,8,3,1,4,1,4,1,4,1,4,1,5,1,5,1,5,
		3,5,48,8,5,1,6,1,6,1,6,1,6,1,6,0,0,7,0,2,4,6,8,10,12,0,0,55,0,17,1,0,0,
		0,2,27,1,0,0,0,4,29,1,0,0,0,6,38,1,0,0,0,8,40,1,0,0,0,10,47,1,0,0,0,12,
		49,1,0,0,0,14,16,3,2,1,0,15,14,1,0,0,0,16,19,1,0,0,0,17,15,1,0,0,0,17,
		18,1,0,0,0,18,20,1,0,0,0,19,17,1,0,0,0,20,21,5,0,0,1,21,1,1,0,0,0,22,28,
		3,4,2,0,23,28,3,8,4,0,24,28,3,12,6,0,25,28,5,1,0,0,26,28,5,13,0,0,27,22,
		1,0,0,0,27,23,1,0,0,0,27,24,1,0,0,0,27,25,1,0,0,0,27,26,1,0,0,0,28,3,1,
		0,0,0,29,30,5,2,0,0,30,31,5,14,0,0,31,32,5,5,0,0,32,33,3,6,3,0,33,34,5,
		6,0,0,34,5,1,0,0,0,35,39,5,15,0,0,36,39,5,12,0,0,37,39,5,14,0,0,38,35,
		1,0,0,0,38,36,1,0,0,0,38,37,1,0,0,0,39,7,1,0,0,0,40,41,5,3,0,0,41,42,3,
		10,5,0,42,43,5,6,0,0,43,9,1,0,0,0,44,48,5,16,0,0,45,48,5,15,0,0,46,48,
		5,14,0,0,47,44,1,0,0,0,47,45,1,0,0,0,47,46,1,0,0,0,48,11,1,0,0,0,49,50,
		5,4,0,0,50,51,5,15,0,0,51,52,5,6,0,0,52,13,1,0,0,0,4,17,27,38,47
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace FQL.Parser
