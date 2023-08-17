// Generated from c:\projects\Chevin\Sandbox\FQL\FQL.Parser\FQLLexer.g4 by ANTLR 4.9.2
import org.antlr.v4.runtime.Lexer;
import org.antlr.v4.runtime.CharStream;
import org.antlr.v4.runtime.Token;
import org.antlr.v4.runtime.TokenStream;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.misc.*;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class FQLLexer extends Lexer {
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
		COMMENTS_CHANNEL=2, DIRECTIVE=3;
	public static final int
		INTERPOLATED_STRING_MODE=1, INTERPOLATION_MODE=2;
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN", "COMMENTS_CHANNEL", "DIRECTIVE"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE", "INTERPOLATED_STRING_MODE", "INTERPOLATION_MODE"
	};

	private static String[] makeRuleNames() {
		return new String[] {
			"BEGIN", "END", "READ", "WRITE", "PRINT", "CONNECTION", "VAR", "OPEN_BRACE", 
			"CLOSE_BRACE", "INTERPOLATED_STRING_START", "STRING_END", "INTERPOLATION_START", 
			"STRING_CONTENT", "INTERPOLATION_END", "INTERPOLATION_ID", "OPEN_BRACKET", 
			"CLOSE_BRACKET", "OPEN_PARENS", "CLOSE_PARENS", "DOT", "COMMA", "COLON", 
			"SEMICOLON", "PLUS", "MINUS", "STAR", "DIV", "PERCENT", "AMP", "BITWISE_OR", 
			"CARET", "BANG", "TILDE", "ASSIGNMENT", "LT", "GT", "INTERR", "DOUBLE_COLON", 
			"OP_COALESCING", "OP_INC", "OP_DEC", "OP_AND", "OP_OR", "OP_PTR", "OP_EQ", 
			"OP_NE", "OP_LE", "OP_GE", "OP_ADD_ASSIGNMENT", "OP_SUB_ASSIGNMENT", 
			"OP_MULT_ASSIGNMENT", "OP_DIV_ASSIGNMENT", "OP_MOD_ASSIGNMENT", "OP_AND_ASSIGNMENT", 
			"OP_OR_ASSIGNMENT", "OP_XOR_ASSIGNMENT", "OP_LEFT_SHIFT", "OP_LEFT_SHIFT_ASSIGNMENT", 
			"OP_COALESCING_ASSIGNMENT", "OP_RANGE", "STRING", "ID", "NUMBER", "SINGLE_LINE_COMMENT", 
			"MULTI_LINE_COMMENT", "WS"
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


	public FQLLexer(CharStream input) {
		super(input);
		_interp = new LexerATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@Override
	public String getGrammarFileName() { return "FQLLexer.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public String[] getChannelNames() { return channelNames; }

	@Override
	public String[] getModeNames() { return modeNames; }

	@Override
	public ATN getATN() { return _ATN; }

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2D\u0179\b\1\b\1\b"+
		"\1\4\2\t\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n"+
		"\t\n\4\13\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21"+
		"\4\22\t\22\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30"+
		"\4\31\t\31\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37"+
		"\4 \t \4!\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)\4*\t"+
		"*\4+\t+\4,\t,\4-\t-\4.\t.\4/\t/\4\60\t\60\4\61\t\61\4\62\t\62\4\63\t\63"+
		"\4\64\t\64\4\65\t\65\4\66\t\66\4\67\t\67\48\t8\49\t9\4:\t:\4;\t;\4<\t"+
		"<\4=\t=\4>\t>\4?\t?\4@\t@\4A\tA\4B\tB\4C\tC\3\2\3\2\3\2\3\2\3\2\3\2\3"+
		"\3\3\3\3\3\3\3\3\4\3\4\3\4\3\4\3\4\3\5\3\5\3\5\3\5\3\5\3\5\3\6\3\6\3\6"+
		"\3\6\3\6\3\6\3\7\3\7\3\7\3\7\3\7\3\7\3\7\3\7\3\7\3\7\3\7\3\b\3\b\3\b\3"+
		"\b\3\t\3\t\3\n\3\n\3\13\3\13\3\13\3\13\3\13\3\f\3\f\3\f\3\f\3\r\3\r\3"+
		"\r\3\r\3\16\6\16\u00c6\n\16\r\16\16\16\u00c7\3\17\3\17\3\17\3\17\3\20"+
		"\3\20\7\20\u00d0\n\20\f\20\16\20\u00d3\13\20\3\21\3\21\3\22\3\22\3\23"+
		"\3\23\3\24\3\24\3\25\3\25\3\26\3\26\3\27\3\27\3\30\3\30\3\31\3\31\3\32"+
		"\3\32\3\33\3\33\3\34\3\34\3\35\3\35\3\36\3\36\3\37\3\37\3 \3 \3!\3!\3"+
		"\"\3\"\3#\3#\3$\3$\3%\3%\3&\3&\3\'\3\'\3\'\3(\3(\3(\3)\3)\3)\3*\3*\3*"+
		"\3+\3+\3+\3,\3,\3,\3-\3-\3-\3.\3.\3.\3/\3/\3/\3\60\3\60\3\60\3\61\3\61"+
		"\3\61\3\62\3\62\3\62\3\63\3\63\3\63\3\64\3\64\3\64\3\65\3\65\3\65\3\66"+
		"\3\66\3\66\3\67\3\67\3\67\38\38\38\39\39\39\3:\3:\3:\3;\3;\3;\3;\3<\3"+
		"<\3<\3<\3=\3=\3=\3>\3>\7>\u014a\n>\f>\16>\u014d\13>\3>\3>\3?\3?\7?\u0153"+
		"\n?\f?\16?\u0156\13?\3@\6@\u0159\n@\r@\16@\u015a\3A\3A\3A\3A\7A\u0161"+
		"\nA\fA\16A\u0164\13A\3A\3A\3B\3B\3B\3B\7B\u016c\nB\fB\16B\u016f\13B\3"+
		"B\3B\3B\3B\3B\3C\3C\3C\3C\3\u016d\2D\5\3\7\4\t\5\13\6\r\7\17\b\21\t\23"+
		"\n\25\13\27\f\31\r\33\16\35\17\37\20!\21#\22%\23\'\24)\25+\26-\27/\30"+
		"\61\31\63\32\65\33\67\349\35;\36=\37? A!C\"E#G$I%K&M\'O(Q)S*U+W,Y-[.]"+
		"/_\60a\61c\62e\63g\64i\65k\66m\67o8q9s:u;w<y={>}?\177@\u0081A\u0083B\u0085"+
		"C\u0087D\5\2\3\4\b\5\2$$}}\177\177\5\2C\\aac|\6\2\62;C\\aac|\5\2\f\f\17"+
		"\17$$\6\2\f\f\17\17\u0087\u0087\u202a\u202b\5\2\13\f\17\17\"\"\2\u017d"+
		"\2\5\3\2\2\2\2\7\3\2\2\2\2\t\3\2\2\2\2\13\3\2\2\2\2\r\3\2\2\2\2\17\3\2"+
		"\2\2\2\21\3\2\2\2\2\23\3\2\2\2\2\25\3\2\2\2\2\27\3\2\2\2\2#\3\2\2\2\2"+
		"%\3\2\2\2\2\'\3\2\2\2\2)\3\2\2\2\2+\3\2\2\2\2-\3\2\2\2\2/\3\2\2\2\2\61"+
		"\3\2\2\2\2\63\3\2\2\2\2\65\3\2\2\2\2\67\3\2\2\2\29\3\2\2\2\2;\3\2\2\2"+
		"\2=\3\2\2\2\2?\3\2\2\2\2A\3\2\2\2\2C\3\2\2\2\2E\3\2\2\2\2G\3\2\2\2\2I"+
		"\3\2\2\2\2K\3\2\2\2\2M\3\2\2\2\2O\3\2\2\2\2Q\3\2\2\2\2S\3\2\2\2\2U\3\2"+
		"\2\2\2W\3\2\2\2\2Y\3\2\2\2\2[\3\2\2\2\2]\3\2\2\2\2_\3\2\2\2\2a\3\2\2\2"+
		"\2c\3\2\2\2\2e\3\2\2\2\2g\3\2\2\2\2i\3\2\2\2\2k\3\2\2\2\2m\3\2\2\2\2o"+
		"\3\2\2\2\2q\3\2\2\2\2s\3\2\2\2\2u\3\2\2\2\2w\3\2\2\2\2y\3\2\2\2\2{\3\2"+
		"\2\2\2}\3\2\2\2\2\177\3\2\2\2\2\u0081\3\2\2\2\2\u0083\3\2\2\2\2\u0085"+
		"\3\2\2\2\2\u0087\3\2\2\2\3\31\3\2\2\2\3\33\3\2\2\2\3\35\3\2\2\2\4\37\3"+
		"\2\2\2\4!\3\2\2\2\5\u0089\3\2\2\2\7\u008f\3\2\2\2\t\u0093\3\2\2\2\13\u0098"+
		"\3\2\2\2\r\u009e\3\2\2\2\17\u00a4\3\2\2\2\21\u00af\3\2\2\2\23\u00b3\3"+
		"\2\2\2\25\u00b5\3\2\2\2\27\u00b7\3\2\2\2\31\u00bc\3\2\2\2\33\u00c0\3\2"+
		"\2\2\35\u00c5\3\2\2\2\37\u00c9\3\2\2\2!\u00cd\3\2\2\2#\u00d4\3\2\2\2%"+
		"\u00d6\3\2\2\2\'\u00d8\3\2\2\2)\u00da\3\2\2\2+\u00dc\3\2\2\2-\u00de\3"+
		"\2\2\2/\u00e0\3\2\2\2\61\u00e2\3\2\2\2\63\u00e4\3\2\2\2\65\u00e6\3\2\2"+
		"\2\67\u00e8\3\2\2\29\u00ea\3\2\2\2;\u00ec\3\2\2\2=\u00ee\3\2\2\2?\u00f0"+
		"\3\2\2\2A\u00f2\3\2\2\2C\u00f4\3\2\2\2E\u00f6\3\2\2\2G\u00f8\3\2\2\2I"+
		"\u00fa\3\2\2\2K\u00fc\3\2\2\2M\u00fe\3\2\2\2O\u0100\3\2\2\2Q\u0103\3\2"+
		"\2\2S\u0106\3\2\2\2U\u0109\3\2\2\2W\u010c\3\2\2\2Y\u010f\3\2\2\2[\u0112"+
		"\3\2\2\2]\u0115\3\2\2\2_\u0118\3\2\2\2a\u011b\3\2\2\2c\u011e\3\2\2\2e"+
		"\u0121\3\2\2\2g\u0124\3\2\2\2i\u0127\3\2\2\2k\u012a\3\2\2\2m\u012d\3\2"+
		"\2\2o\u0130\3\2\2\2q\u0133\3\2\2\2s\u0136\3\2\2\2u\u0139\3\2\2\2w\u013c"+
		"\3\2\2\2y\u0140\3\2\2\2{\u0144\3\2\2\2}\u0147\3\2\2\2\177\u0150\3\2\2"+
		"\2\u0081\u0158\3\2\2\2\u0083\u015c\3\2\2\2\u0085\u0167\3\2\2\2\u0087\u0175"+
		"\3\2\2\2\u0089\u008a\7D\2\2\u008a\u008b\7G\2\2\u008b\u008c\7I\2\2\u008c"+
		"\u008d\7K\2\2\u008d\u008e\7P\2\2\u008e\6\3\2\2\2\u008f\u0090\7G\2\2\u0090"+
		"\u0091\7P\2\2\u0091\u0092\7F\2\2\u0092\b\3\2\2\2\u0093\u0094\7T\2\2\u0094"+
		"\u0095\7G\2\2\u0095\u0096\7C\2\2\u0096\u0097\7F\2\2\u0097\n\3\2\2\2\u0098"+
		"\u0099\7Y\2\2\u0099\u009a\7T\2\2\u009a\u009b\7K\2\2\u009b\u009c\7V\2\2"+
		"\u009c\u009d\7G\2\2\u009d\f\3\2\2\2\u009e\u009f\7R\2\2\u009f\u00a0\7T"+
		"\2\2\u00a0\u00a1\7K\2\2\u00a1\u00a2\7P\2\2\u00a2\u00a3\7V\2\2\u00a3\16"+
		"\3\2\2\2\u00a4\u00a5\7E\2\2\u00a5\u00a6\7Q\2\2\u00a6\u00a7\7P\2\2\u00a7"+
		"\u00a8\7P\2\2\u00a8\u00a9\7G\2\2\u00a9\u00aa\7E\2\2\u00aa\u00ab\7V\2\2"+
		"\u00ab\u00ac\7K\2\2\u00ac\u00ad\7Q\2\2\u00ad\u00ae\7P\2\2\u00ae\20\3\2"+
		"\2\2\u00af\u00b0\7x\2\2\u00b0\u00b1\7c\2\2\u00b1\u00b2\7t\2\2\u00b2\22"+
		"\3\2\2\2\u00b3\u00b4\7}\2\2\u00b4\24\3\2\2\2\u00b5\u00b6\7\177\2\2\u00b6"+
		"\26\3\2\2\2\u00b7\u00b8\7&\2\2\u00b8\u00b9\7$\2\2\u00b9\u00ba\3\2\2\2"+
		"\u00ba\u00bb\b\13\2\2\u00bb\30\3\2\2\2\u00bc\u00bd\7$\2\2\u00bd\u00be"+
		"\3\2\2\2\u00be\u00bf\b\f\3\2\u00bf\32\3\2\2\2\u00c0\u00c1\7}\2\2\u00c1"+
		"\u00c2\3\2\2\2\u00c2\u00c3\b\r\4\2\u00c3\34\3\2\2\2\u00c4\u00c6\n\2\2"+
		"\2\u00c5\u00c4\3\2\2\2\u00c6\u00c7\3\2\2\2\u00c7\u00c5\3\2\2\2\u00c7\u00c8"+
		"\3\2\2\2\u00c8\36\3\2\2\2\u00c9\u00ca\7\177\2\2\u00ca\u00cb\3\2\2\2\u00cb"+
		"\u00cc\b\17\3\2\u00cc \3\2\2\2\u00cd\u00d1\t\3\2\2\u00ce\u00d0\t\4\2\2"+
		"\u00cf\u00ce\3\2\2\2\u00d0\u00d3\3\2\2\2\u00d1\u00cf\3\2\2\2\u00d1\u00d2"+
		"\3\2\2\2\u00d2\"\3\2\2\2\u00d3\u00d1\3\2\2\2\u00d4\u00d5\7]\2\2\u00d5"+
		"$\3\2\2\2\u00d6\u00d7\7_\2\2\u00d7&\3\2\2\2\u00d8\u00d9\7*\2\2\u00d9("+
		"\3\2\2\2\u00da\u00db\7+\2\2\u00db*\3\2\2\2\u00dc\u00dd\7\60\2\2\u00dd"+
		",\3\2\2\2\u00de\u00df\7.\2\2\u00df.\3\2\2\2\u00e0\u00e1\7<\2\2\u00e1\60"+
		"\3\2\2\2\u00e2\u00e3\7=\2\2\u00e3\62\3\2\2\2\u00e4\u00e5\7-\2\2\u00e5"+
		"\64\3\2\2\2\u00e6\u00e7\7/\2\2\u00e7\66\3\2\2\2\u00e8\u00e9\7,\2\2\u00e9"+
		"8\3\2\2\2\u00ea\u00eb\7\61\2\2\u00eb:\3\2\2\2\u00ec\u00ed\7\'\2\2\u00ed"+
		"<\3\2\2\2\u00ee\u00ef\7(\2\2\u00ef>\3\2\2\2\u00f0\u00f1\7~\2\2\u00f1@"+
		"\3\2\2\2\u00f2\u00f3\7`\2\2\u00f3B\3\2\2\2\u00f4\u00f5\7#\2\2\u00f5D\3"+
		"\2\2\2\u00f6\u00f7\7\u0080\2\2\u00f7F\3\2\2\2\u00f8\u00f9\7?\2\2\u00f9"+
		"H\3\2\2\2\u00fa\u00fb\7>\2\2\u00fbJ\3\2\2\2\u00fc\u00fd\7@\2\2\u00fdL"+
		"\3\2\2\2\u00fe\u00ff\7A\2\2\u00ffN\3\2\2\2\u0100\u0101\7<\2\2\u0101\u0102"+
		"\7<\2\2\u0102P\3\2\2\2\u0103\u0104\7A\2\2\u0104\u0105\7A\2\2\u0105R\3"+
		"\2\2\2\u0106\u0107\7-\2\2\u0107\u0108\7-\2\2\u0108T\3\2\2\2\u0109\u010a"+
		"\7/\2\2\u010a\u010b\7/\2\2\u010bV\3\2\2\2\u010c\u010d\7(\2\2\u010d\u010e"+
		"\7(\2\2\u010eX\3\2\2\2\u010f\u0110\7~\2\2\u0110\u0111\7~\2\2\u0111Z\3"+
		"\2\2\2\u0112\u0113\7/\2\2\u0113\u0114\7@\2\2\u0114\\\3\2\2\2\u0115\u0116"+
		"\7?\2\2\u0116\u0117\7?\2\2\u0117^\3\2\2\2\u0118\u0119\7#\2\2\u0119\u011a"+
		"\7?\2\2\u011a`\3\2\2\2\u011b\u011c\7>\2\2\u011c\u011d\7?\2\2\u011db\3"+
		"\2\2\2\u011e\u011f\7@\2\2\u011f\u0120\7?\2\2\u0120d\3\2\2\2\u0121\u0122"+
		"\7-\2\2\u0122\u0123\7?\2\2\u0123f\3\2\2\2\u0124\u0125\7/\2\2\u0125\u0126"+
		"\7?\2\2\u0126h\3\2\2\2\u0127\u0128\7,\2\2\u0128\u0129\7?\2\2\u0129j\3"+
		"\2\2\2\u012a\u012b\7\61\2\2\u012b\u012c\7?\2\2\u012cl\3\2\2\2\u012d\u012e"+
		"\7\'\2\2\u012e\u012f\7?\2\2\u012fn\3\2\2\2\u0130\u0131\7(\2\2\u0131\u0132"+
		"\7?\2\2\u0132p\3\2\2\2\u0133\u0134\7~\2\2\u0134\u0135\7?\2\2\u0135r\3"+
		"\2\2\2\u0136\u0137\7`\2\2\u0137\u0138\7?\2\2\u0138t\3\2\2\2\u0139\u013a"+
		"\7>\2\2\u013a\u013b\7>\2\2\u013bv\3\2\2\2\u013c\u013d\7>\2\2\u013d\u013e"+
		"\7>\2\2\u013e\u013f\7?\2\2\u013fx\3\2\2\2\u0140\u0141\7A\2\2\u0141\u0142"+
		"\7A\2\2\u0142\u0143\7?\2\2\u0143z\3\2\2\2\u0144\u0145\7\60\2\2\u0145\u0146"+
		"\7\60\2\2\u0146|\3\2\2\2\u0147\u014b\7$\2\2\u0148\u014a\n\5\2\2\u0149"+
		"\u0148\3\2\2\2\u014a\u014d\3\2\2\2\u014b\u0149\3\2\2\2\u014b\u014c\3\2"+
		"\2\2\u014c\u014e\3\2\2\2\u014d\u014b\3\2\2\2\u014e\u014f\7$\2\2\u014f"+
		"~\3\2\2\2\u0150\u0154\t\3\2\2\u0151\u0153\t\4\2\2\u0152\u0151\3\2\2\2"+
		"\u0153\u0156\3\2\2\2\u0154\u0152\3\2\2\2\u0154\u0155\3\2\2\2\u0155\u0080"+
		"\3\2\2\2\u0156\u0154\3\2\2\2\u0157\u0159\4\62;\2\u0158\u0157\3\2\2\2\u0159"+
		"\u015a\3\2\2\2\u015a\u0158\3\2\2\2\u015a\u015b\3\2\2\2\u015b\u0082\3\2"+
		"\2\2\u015c\u015d\7\61\2\2\u015d\u015e\7\61\2\2\u015e\u0162\3\2\2\2\u015f"+
		"\u0161\n\6\2\2\u0160\u015f\3\2\2\2\u0161\u0164\3\2\2\2\u0162\u0160\3\2"+
		"\2\2\u0162\u0163\3\2\2\2\u0163\u0165\3\2\2\2\u0164\u0162\3\2\2\2\u0165"+
		"\u0166\bA\5\2\u0166\u0084\3\2\2\2\u0167\u0168\7\61\2\2\u0168\u0169\7,"+
		"\2\2\u0169\u016d\3\2\2\2\u016a\u016c\13\2\2\2\u016b\u016a\3\2\2\2\u016c"+
		"\u016f\3\2\2\2\u016d\u016e\3\2\2\2\u016d\u016b\3\2\2\2\u016e\u0170\3\2"+
		"\2\2\u016f\u016d\3\2\2\2\u0170\u0171\7,\2\2\u0171\u0172\7\61\2\2\u0172"+
		"\u0173\3\2\2\2\u0173\u0174\bB\5\2\u0174\u0086\3\2\2\2\u0175\u0176\t\7"+
		"\2\2\u0176\u0177\3\2\2\2\u0177\u0178\bC\6\2\u0178\u0088\3\2\2\2\f\2\3"+
		"\4\u00c7\u00d1\u014b\u0154\u015a\u0162\u016d\7\7\3\2\6\2\2\7\4\2\2\4\2"+
		"\b\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}