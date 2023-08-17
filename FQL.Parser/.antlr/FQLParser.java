// Generated from c:\projects\Chevin\Sandbox\FQL\FQL.Parser\FQLParser.g4 by ANTLR 4.9.2
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class FQLParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.9.2", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		BEGIN=1, END=2, READ=3, WRITE=4, PRINT=5, CONNECTION=6, VAR=7, OPEN_BRACE=8, 
		CLOSE_BRACE=9, INTERPOLATED_STRING_START=10, STRING_END=11, INTERPOLATION_START=12, 
		STRING_CONTENT=13, INTERPOLATION_END=14, INTERPOLATION_ID=15, OPEN_BRACKET=16, 
		CLOSE_BRACKET=17, OPEN_PARENS=18, CLOSE_PARENS=19, DOT=20, COMMA=21, COLON=22, 
		SEMICOLON=23, PLUS=24, MINUS=25, STAR=26, DIV=27, PERCENT=28, AMP=29, 
		BITWISE_OR=30, CARET=31, BANG=32, TILDE=33, ASSIGNMENT=34, LT=35, GT=36, 
		INTERR=37, DOUBLE_COLON=38, OP_COALESCING=39, OP_INC=40, OP_DEC=41, OP_AND=42, 
		OP_OR=43, OP_PTR=44, OP_EQ=45, OP_NE=46, OP_LE=47, OP_GE=48, OP_ADD_ASSIGNMENT=49, 
		OP_SUB_ASSIGNMENT=50, OP_MULT_ASSIGNMENT=51, OP_DIV_ASSIGNMENT=52, OP_MOD_ASSIGNMENT=53, 
		OP_AND_ASSIGNMENT=54, OP_OR_ASSIGNMENT=55, OP_XOR_ASSIGNMENT=56, OP_LEFT_SHIFT=57, 
		OP_LEFT_SHIFT_ASSIGNMENT=58, OP_COALESCING_ASSIGNMENT=59, OP_RANGE=60, 
		STRING=61, ID=62, NUMBER=63, SINGLE_LINE_COMMENT=64, MULTI_LINE_COMMENT=65, 
		WS=66;
	public static final int
		RULE_program = 0, RULE_statements = 1, RULE_statement = 2, RULE_assignment = 3, 
		RULE_readStatement = 4, RULE_writeStatement = 5, RULE_identifierList = 6, 
		RULE_expressionList = 7, RULE_expression = 8, RULE_factor = 9, RULE_integer = 10, 
		RULE_operator = 11, RULE_identifier = 12, RULE_string = 13, RULE_interpolatedString = 14, 
		RULE_interpolation = 15;
	private static String[] makeRuleNames() {
		return new String[] {
			"program", "statements", "statement", "assignment", "readStatement", 
			"writeStatement", "identifierList", "expressionList", "expression", "factor", 
			"integer", "operator", "identifier", "string", "interpolatedString", 
			"interpolation"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'BEGIN'", "'END'", "'READ'", "'WRITE'", "'PRINT'", "'CONNECTION'", 
			"'var'", null, null, "'$\"'", "'\"'", null, null, null, null, "'['", 
			"']'", "'('", "')'", "'.'", "','", "':'", "';'", "'+'", "'-'", "'*'", 
			"'/'", "'%'", "'&'", "'|'", "'^'", "'!'", "'~'", "'='", "'<'", "'>'", 
			"'?'", "'::'", "'??'", "'++'", "'--'", "'&&'", "'||'", "'->'", "'=='", 
			"'!='", "'<='", "'>='", "'+='", "'-='", "'*='", "'/='", "'%='", "'&='", 
			"'|='", "'^='", "'<<'", "'<<='", "'??='", "'..'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, "BEGIN", "END", "READ", "WRITE", "PRINT", "CONNECTION", "VAR", 
			"OPEN_BRACE", "CLOSE_BRACE", "INTERPOLATED_STRING_START", "STRING_END", 
			"INTERPOLATION_START", "STRING_CONTENT", "INTERPOLATION_END", "INTERPOLATION_ID", 
			"OPEN_BRACKET", "CLOSE_BRACKET", "OPEN_PARENS", "CLOSE_PARENS", "DOT", 
			"COMMA", "COLON", "SEMICOLON", "PLUS", "MINUS", "STAR", "DIV", "PERCENT", 
			"AMP", "BITWISE_OR", "CARET", "BANG", "TILDE", "ASSIGNMENT", "LT", "GT", 
			"INTERR", "DOUBLE_COLON", "OP_COALESCING", "OP_INC", "OP_DEC", "OP_AND", 
			"OP_OR", "OP_PTR", "OP_EQ", "OP_NE", "OP_LE", "OP_GE", "OP_ADD_ASSIGNMENT", 
			"OP_SUB_ASSIGNMENT", "OP_MULT_ASSIGNMENT", "OP_DIV_ASSIGNMENT", "OP_MOD_ASSIGNMENT", 
			"OP_AND_ASSIGNMENT", "OP_OR_ASSIGNMENT", "OP_XOR_ASSIGNMENT", "OP_LEFT_SHIFT", 
			"OP_LEFT_SHIFT_ASSIGNMENT", "OP_COALESCING_ASSIGNMENT", "OP_RANGE", "STRING", 
			"ID", "NUMBER", "SINGLE_LINE_COMMENT", "MULTI_LINE_COMMENT", "WS"
		};
	}
	private static final String[] _SYMBOLIC_NAMES = makeSymbolicNames();
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}

	@Override
	public String getGrammarFileName() { return "FQLParser.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public FQLParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	public static class ProgramContext extends ParserRuleContext {
		public TerminalNode BEGIN() { return getToken(FQLParser.BEGIN, 0); }
		public StatementsContext statements() {
			return getRuleContext(StatementsContext.class,0);
		}
		public TerminalNode END() { return getToken(FQLParser.END, 0); }
		public TerminalNode EOF() { return getToken(FQLParser.EOF, 0); }
		public ProgramContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_program; }
	}

	public final ProgramContext program() throws RecognitionException {
		ProgramContext _localctx = new ProgramContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_program);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(32);
			match(BEGIN);
			setState(33);
			statements(0);
			setState(34);
			match(END);
			setState(35);
			match(EOF);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class StatementsContext extends ParserRuleContext {
		public StatementContext statement() {
			return getRuleContext(StatementContext.class,0);
		}
		public StatementsContext statements() {
			return getRuleContext(StatementsContext.class,0);
		}
		public StatementsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_statements; }
	}

	public final StatementsContext statements() throws RecognitionException {
		return statements(0);
	}

	private StatementsContext statements(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		StatementsContext _localctx = new StatementsContext(_ctx, _parentState);
		StatementsContext _prevctx = _localctx;
		int _startState = 2;
		enterRecursionRule(_localctx, 2, RULE_statements, _p);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			{
			setState(38);
			statement();
			}
			_ctx.stop = _input.LT(-1);
			setState(44);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,0,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new StatementsContext(_parentctx, _parentState);
					pushNewRecursionContext(_localctx, _startState, RULE_statements);
					setState(40);
					if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
					setState(41);
					statement();
					}
					} 
				}
				setState(46);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,0,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public static class StatementContext extends ParserRuleContext {
		public AssignmentContext assignment() {
			return getRuleContext(AssignmentContext.class,0);
		}
		public TerminalNode SEMICOLON() { return getToken(FQLParser.SEMICOLON, 0); }
		public ReadStatementContext readStatement() {
			return getRuleContext(ReadStatementContext.class,0);
		}
		public WriteStatementContext writeStatement() {
			return getRuleContext(WriteStatementContext.class,0);
		}
		public StatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_statement; }
	}

	public final StatementContext statement() throws RecognitionException {
		StatementContext _localctx = new StatementContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_statement);
		try {
			setState(56);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case VAR:
				enterOuterAlt(_localctx, 1);
				{
				setState(47);
				assignment();
				setState(48);
				match(SEMICOLON);
				}
				break;
			case READ:
				enterOuterAlt(_localctx, 2);
				{
				setState(50);
				readStatement();
				setState(51);
				match(SEMICOLON);
				}
				break;
			case WRITE:
				enterOuterAlt(_localctx, 3);
				{
				setState(53);
				writeStatement();
				setState(54);
				match(SEMICOLON);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class AssignmentContext extends ParserRuleContext {
		public TerminalNode VAR() { return getToken(FQLParser.VAR, 0); }
		public IdentifierContext identifier() {
			return getRuleContext(IdentifierContext.class,0);
		}
		public TerminalNode ASSIGNMENT() { return getToken(FQLParser.ASSIGNMENT, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public AssignmentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_assignment; }
	}

	public final AssignmentContext assignment() throws RecognitionException {
		AssignmentContext _localctx = new AssignmentContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_assignment);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(58);
			match(VAR);
			setState(59);
			identifier();
			setState(60);
			match(ASSIGNMENT);
			setState(61);
			expression();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ReadStatementContext extends ParserRuleContext {
		public TerminalNode READ() { return getToken(FQLParser.READ, 0); }
		public IdentifierListContext identifierList() {
			return getRuleContext(IdentifierListContext.class,0);
		}
		public ReadStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_readStatement; }
	}

	public final ReadStatementContext readStatement() throws RecognitionException {
		ReadStatementContext _localctx = new ReadStatementContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_readStatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(63);
			match(READ);
			setState(64);
			identifierList(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class WriteStatementContext extends ParserRuleContext {
		public TerminalNode WRITE() { return getToken(FQLParser.WRITE, 0); }
		public ExpressionListContext expressionList() {
			return getRuleContext(ExpressionListContext.class,0);
		}
		public WriteStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_writeStatement; }
	}

	public final WriteStatementContext writeStatement() throws RecognitionException {
		WriteStatementContext _localctx = new WriteStatementContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_writeStatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(66);
			match(WRITE);
			setState(67);
			expressionList(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class IdentifierListContext extends ParserRuleContext {
		public IdentifierContext identifier() {
			return getRuleContext(IdentifierContext.class,0);
		}
		public IdentifierListContext identifierList() {
			return getRuleContext(IdentifierListContext.class,0);
		}
		public TerminalNode COMMA() { return getToken(FQLParser.COMMA, 0); }
		public IdentifierListContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_identifierList; }
	}

	public final IdentifierListContext identifierList() throws RecognitionException {
		return identifierList(0);
	}

	private IdentifierListContext identifierList(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		IdentifierListContext _localctx = new IdentifierListContext(_ctx, _parentState);
		IdentifierListContext _prevctx = _localctx;
		int _startState = 12;
		enterRecursionRule(_localctx, 12, RULE_identifierList, _p);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			{
			setState(70);
			identifier();
			}
			_ctx.stop = _input.LT(-1);
			setState(77);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,2,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new IdentifierListContext(_parentctx, _parentState);
					pushNewRecursionContext(_localctx, _startState, RULE_identifierList);
					setState(72);
					if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
					setState(73);
					match(COMMA);
					setState(74);
					identifier();
					}
					} 
				}
				setState(79);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,2,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public static class ExpressionListContext extends ParserRuleContext {
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public ExpressionListContext expressionList() {
			return getRuleContext(ExpressionListContext.class,0);
		}
		public TerminalNode COMMA() { return getToken(FQLParser.COMMA, 0); }
		public ExpressionListContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expressionList; }
	}

	public final ExpressionListContext expressionList() throws RecognitionException {
		return expressionList(0);
	}

	private ExpressionListContext expressionList(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		ExpressionListContext _localctx = new ExpressionListContext(_ctx, _parentState);
		ExpressionListContext _prevctx = _localctx;
		int _startState = 14;
		enterRecursionRule(_localctx, 14, RULE_expressionList, _p);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			{
			setState(81);
			expression();
			}
			_ctx.stop = _input.LT(-1);
			setState(88);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,3,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new ExpressionListContext(_parentctx, _parentState);
					pushNewRecursionContext(_localctx, _startState, RULE_expressionList);
					setState(83);
					if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
					setState(84);
					match(COMMA);
					setState(85);
					expression();
					}
					} 
				}
				setState(90);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,3,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public static class ExpressionContext extends ParserRuleContext {
		public ExpressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expression; }
	 
		public ExpressionContext() { }
		public void copyFrom(ExpressionContext ctx) {
			super.copyFrom(ctx);
		}
	}
	public static class ComplexFactorContext extends ExpressionContext {
		public FactorContext factor() {
			return getRuleContext(FactorContext.class,0);
		}
		public OperatorContext operator() {
			return getRuleContext(OperatorContext.class,0);
		}
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public ComplexFactorContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class SimpleFactorContext extends ExpressionContext {
		public FactorContext factor() {
			return getRuleContext(FactorContext.class,0);
		}
		public SimpleFactorContext(ExpressionContext ctx) { copyFrom(ctx); }
	}

	public final ExpressionContext expression() throws RecognitionException {
		ExpressionContext _localctx = new ExpressionContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_expression);
		try {
			setState(96);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,4,_ctx) ) {
			case 1:
				_localctx = new ComplexFactorContext(_localctx);
				enterOuterAlt(_localctx, 1);
				{
				setState(91);
				factor();
				setState(92);
				operator();
				setState(93);
				expression();
				}
				break;
			case 2:
				_localctx = new SimpleFactorContext(_localctx);
				enterOuterAlt(_localctx, 2);
				{
				setState(95);
				factor();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FactorContext extends ParserRuleContext {
		public FactorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_factor; }
	 
		public FactorContext() { }
		public void copyFrom(FactorContext ctx) {
			super.copyFrom(ctx);
		}
	}
	public static class IdentifierFactorContext extends FactorContext {
		public IdentifierContext id;
		public IdentifierContext identifier() {
			return getRuleContext(IdentifierContext.class,0);
		}
		public IdentifierFactorContext(FactorContext ctx) { copyFrom(ctx); }
	}
	public static class StringFactorContext extends FactorContext {
		public StringContext str;
		public StringContext string() {
			return getRuleContext(StringContext.class,0);
		}
		public StringFactorContext(FactorContext ctx) { copyFrom(ctx); }
	}
	public static class ParenExprContext extends FactorContext {
		public TerminalNode OPEN_PARENS() { return getToken(FQLParser.OPEN_PARENS, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public TerminalNode CLOSE_PARENS() { return getToken(FQLParser.CLOSE_PARENS, 0); }
		public ParenExprContext(FactorContext ctx) { copyFrom(ctx); }
	}
	public static class IntFactorContext extends FactorContext {
		public IntegerContext i;
		public IntegerContext integer() {
			return getRuleContext(IntegerContext.class,0);
		}
		public IntFactorContext(FactorContext ctx) { copyFrom(ctx); }
	}

	public final FactorContext factor() throws RecognitionException {
		FactorContext _localctx = new FactorContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_factor);
		try {
			setState(105);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case ID:
				_localctx = new IdentifierFactorContext(_localctx);
				enterOuterAlt(_localctx, 1);
				{
				setState(98);
				((IdentifierFactorContext)_localctx).id = identifier();
				}
				break;
			case INTERPOLATED_STRING_START:
			case STRING:
				_localctx = new StringFactorContext(_localctx);
				enterOuterAlt(_localctx, 2);
				{
				setState(99);
				((StringFactorContext)_localctx).str = string();
				}
				break;
			case MINUS:
			case NUMBER:
				_localctx = new IntFactorContext(_localctx);
				enterOuterAlt(_localctx, 3);
				{
				setState(100);
				((IntFactorContext)_localctx).i = integer();
				}
				break;
			case OPEN_PARENS:
				_localctx = new ParenExprContext(_localctx);
				enterOuterAlt(_localctx, 4);
				{
				setState(101);
				match(OPEN_PARENS);
				setState(102);
				expression();
				setState(103);
				match(CLOSE_PARENS);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class IntegerContext extends ParserRuleContext {
		public TerminalNode NUMBER() { return getToken(FQLParser.NUMBER, 0); }
		public TerminalNode MINUS() { return getToken(FQLParser.MINUS, 0); }
		public IntegerContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_integer; }
	}

	public final IntegerContext integer() throws RecognitionException {
		IntegerContext _localctx = new IntegerContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_integer);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(108);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==MINUS) {
				{
				setState(107);
				match(MINUS);
				}
			}

			setState(110);
			match(NUMBER);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class OperatorContext extends ParserRuleContext {
		public TerminalNode PLUS() { return getToken(FQLParser.PLUS, 0); }
		public TerminalNode MINUS() { return getToken(FQLParser.MINUS, 0); }
		public OperatorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_operator; }
	}

	public final OperatorContext operator() throws RecognitionException {
		OperatorContext _localctx = new OperatorContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_operator);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(112);
			_la = _input.LA(1);
			if ( !(_la==PLUS || _la==MINUS) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class IdentifierContext extends ParserRuleContext {
		public TerminalNode ID() { return getToken(FQLParser.ID, 0); }
		public IdentifierContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_identifier; }
	}

	public final IdentifierContext identifier() throws RecognitionException {
		IdentifierContext _localctx = new IdentifierContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_identifier);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(114);
			match(ID);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class StringContext extends ParserRuleContext {
		public StringContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_string; }
	 
		public StringContext() { }
		public void copyFrom(StringContext ctx) {
			super.copyFrom(ctx);
		}
	}
	public static class InterpolationStringContext extends StringContext {
		public InterpolatedStringContext interpolatedString() {
			return getRuleContext(InterpolatedStringContext.class,0);
		}
		public InterpolationStringContext(StringContext ctx) { copyFrom(ctx); }
	}
	public static class StringLiteralContext extends StringContext {
		public TerminalNode STRING() { return getToken(FQLParser.STRING, 0); }
		public StringLiteralContext(StringContext ctx) { copyFrom(ctx); }
	}

	public final StringContext string() throws RecognitionException {
		StringContext _localctx = new StringContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_string);
		try {
			setState(118);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case INTERPOLATED_STRING_START:
				_localctx = new InterpolationStringContext(_localctx);
				enterOuterAlt(_localctx, 1);
				{
				setState(116);
				interpolatedString();
				}
				break;
			case STRING:
				_localctx = new StringLiteralContext(_localctx);
				enterOuterAlt(_localctx, 2);
				{
				setState(117);
				match(STRING);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class InterpolatedStringContext extends ParserRuleContext {
		public TerminalNode INTERPOLATED_STRING_START() { return getToken(FQLParser.INTERPOLATED_STRING_START, 0); }
		public TerminalNode STRING_END() { return getToken(FQLParser.STRING_END, 0); }
		public List<TerminalNode> STRING_CONTENT() { return getTokens(FQLParser.STRING_CONTENT); }
		public TerminalNode STRING_CONTENT(int i) {
			return getToken(FQLParser.STRING_CONTENT, i);
		}
		public List<InterpolationContext> interpolation() {
			return getRuleContexts(InterpolationContext.class);
		}
		public InterpolationContext interpolation(int i) {
			return getRuleContext(InterpolationContext.class,i);
		}
		public InterpolatedStringContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_interpolatedString; }
	}

	public final InterpolatedStringContext interpolatedString() throws RecognitionException {
		InterpolatedStringContext _localctx = new InterpolatedStringContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_interpolatedString);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(120);
			match(INTERPOLATED_STRING_START);
			setState(125);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==INTERPOLATION_START || _la==STRING_CONTENT) {
				{
				setState(123);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case STRING_CONTENT:
					{
					setState(121);
					match(STRING_CONTENT);
					}
					break;
				case INTERPOLATION_START:
					{
					setState(122);
					interpolation();
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				}
				setState(127);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(128);
			match(STRING_END);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class InterpolationContext extends ParserRuleContext {
		public TerminalNode INTERPOLATION_START() { return getToken(FQLParser.INTERPOLATION_START, 0); }
		public TerminalNode INTERPOLATION_ID() { return getToken(FQLParser.INTERPOLATION_ID, 0); }
		public TerminalNode INTERPOLATION_END() { return getToken(FQLParser.INTERPOLATION_END, 0); }
		public InterpolationContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_interpolation; }
	}

	public final InterpolationContext interpolation() throws RecognitionException {
		InterpolationContext _localctx = new InterpolationContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_interpolation);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(130);
			match(INTERPOLATION_START);
			setState(131);
			match(INTERPOLATION_ID);
			setState(132);
			match(INTERPOLATION_END);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public boolean sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 1:
			return statements_sempred((StatementsContext)_localctx, predIndex);
		case 6:
			return identifierList_sempred((IdentifierListContext)_localctx, predIndex);
		case 7:
			return expressionList_sempred((ExpressionListContext)_localctx, predIndex);
		}
		return true;
	}
	private boolean statements_sempred(StatementsContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0:
			return precpred(_ctx, 2);
		}
		return true;
	}
	private boolean identifierList_sempred(IdentifierListContext _localctx, int predIndex) {
		switch (predIndex) {
		case 1:
			return precpred(_ctx, 2);
		}
		return true;
	}
	private boolean expressionList_sempred(ExpressionListContext _localctx, int predIndex) {
		switch (predIndex) {
		case 2:
			return precpred(_ctx, 2);
		}
		return true;
	}

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3D\u0089\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t"+
		"\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\3\2\3\2\3"+
		"\2\3\2\3\2\3\3\3\3\3\3\3\3\3\3\7\3-\n\3\f\3\16\3\60\13\3\3\4\3\4\3\4\3"+
		"\4\3\4\3\4\3\4\3\4\3\4\5\4;\n\4\3\5\3\5\3\5\3\5\3\5\3\6\3\6\3\6\3\7\3"+
		"\7\3\7\3\b\3\b\3\b\3\b\3\b\3\b\7\bN\n\b\f\b\16\bQ\13\b\3\t\3\t\3\t\3\t"+
		"\3\t\3\t\7\tY\n\t\f\t\16\t\\\13\t\3\n\3\n\3\n\3\n\3\n\5\nc\n\n\3\13\3"+
		"\13\3\13\3\13\3\13\3\13\3\13\5\13l\n\13\3\f\5\fo\n\f\3\f\3\f\3\r\3\r\3"+
		"\16\3\16\3\17\3\17\5\17y\n\17\3\20\3\20\3\20\7\20~\n\20\f\20\16\20\u0081"+
		"\13\20\3\20\3\20\3\21\3\21\3\21\3\21\3\21\2\5\4\16\20\22\2\4\6\b\n\f\16"+
		"\20\22\24\26\30\32\34\36 \2\3\3\2\32\33\2\u0085\2\"\3\2\2\2\4\'\3\2\2"+
		"\2\6:\3\2\2\2\b<\3\2\2\2\nA\3\2\2\2\fD\3\2\2\2\16G\3\2\2\2\20R\3\2\2\2"+
		"\22b\3\2\2\2\24k\3\2\2\2\26n\3\2\2\2\30r\3\2\2\2\32t\3\2\2\2\34x\3\2\2"+
		"\2\36z\3\2\2\2 \u0084\3\2\2\2\"#\7\3\2\2#$\5\4\3\2$%\7\4\2\2%&\7\2\2\3"+
		"&\3\3\2\2\2\'(\b\3\1\2()\5\6\4\2).\3\2\2\2*+\f\4\2\2+-\5\6\4\2,*\3\2\2"+
		"\2-\60\3\2\2\2.,\3\2\2\2./\3\2\2\2/\5\3\2\2\2\60.\3\2\2\2\61\62\5\b\5"+
		"\2\62\63\7\31\2\2\63;\3\2\2\2\64\65\5\n\6\2\65\66\7\31\2\2\66;\3\2\2\2"+
		"\678\5\f\7\289\7\31\2\29;\3\2\2\2:\61\3\2\2\2:\64\3\2\2\2:\67\3\2\2\2"+
		";\7\3\2\2\2<=\7\t\2\2=>\5\32\16\2>?\7$\2\2?@\5\22\n\2@\t\3\2\2\2AB\7\5"+
		"\2\2BC\5\16\b\2C\13\3\2\2\2DE\7\6\2\2EF\5\20\t\2F\r\3\2\2\2GH\b\b\1\2"+
		"HI\5\32\16\2IO\3\2\2\2JK\f\4\2\2KL\7\27\2\2LN\5\32\16\2MJ\3\2\2\2NQ\3"+
		"\2\2\2OM\3\2\2\2OP\3\2\2\2P\17\3\2\2\2QO\3\2\2\2RS\b\t\1\2ST\5\22\n\2"+
		"TZ\3\2\2\2UV\f\4\2\2VW\7\27\2\2WY\5\22\n\2XU\3\2\2\2Y\\\3\2\2\2ZX\3\2"+
		"\2\2Z[\3\2\2\2[\21\3\2\2\2\\Z\3\2\2\2]^\5\24\13\2^_\5\30\r\2_`\5\22\n"+
		"\2`c\3\2\2\2ac\5\24\13\2b]\3\2\2\2ba\3\2\2\2c\23\3\2\2\2dl\5\32\16\2e"+
		"l\5\34\17\2fl\5\26\f\2gh\7\24\2\2hi\5\22\n\2ij\7\25\2\2jl\3\2\2\2kd\3"+
		"\2\2\2ke\3\2\2\2kf\3\2\2\2kg\3\2\2\2l\25\3\2\2\2mo\7\33\2\2nm\3\2\2\2"+
		"no\3\2\2\2op\3\2\2\2pq\7A\2\2q\27\3\2\2\2rs\t\2\2\2s\31\3\2\2\2tu\7@\2"+
		"\2u\33\3\2\2\2vy\5\36\20\2wy\7?\2\2xv\3\2\2\2xw\3\2\2\2y\35\3\2\2\2z\177"+
		"\7\f\2\2{~\7\17\2\2|~\5 \21\2}{\3\2\2\2}|\3\2\2\2~\u0081\3\2\2\2\177}"+
		"\3\2\2\2\177\u0080\3\2\2\2\u0080\u0082\3\2\2\2\u0081\177\3\2\2\2\u0082"+
		"\u0083\7\r\2\2\u0083\37\3\2\2\2\u0084\u0085\7\16\2\2\u0085\u0086\7\21"+
		"\2\2\u0086\u0087\7\20\2\2\u0087!\3\2\2\2\f.:OZbknx}\177";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}