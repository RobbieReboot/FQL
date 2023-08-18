//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\projects\Chevin\Sandbox\FQL\FQL.Parser\FQLLexer.g4 by ANTLR 4.13.0

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
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.0")]
[System.CLSCompliant(false)]
public partial class FQLLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		BEGIN=1, END=2, READ=3, WRITE=4, PRINT=5, CONNECTION=6, VAR=7, OPEN_BRACE=8, 
		CLOSE_BRACE=9, INTERPOLATED_STRING_START=10, STRING_END=11, INTERPOLATION_START=12, 
		STRING_CONTENT=13, INTERPOLATION_END=14, INTERPOLATION_ID=15, OPEN_BRACKET=16, 
		CLOSE_BRACKET=17, OPEN_PARENS=18, CLOSE_PARENS=19, DOT=20, COMMA=21, COLON=22, 
		SEMICOLON=23, PLUS=24, MINUS=25, ASTERISK=26, DIVIDE=27, PERCENT=28, AMP=29, 
		BITWISE_OR=30, CARET=31, BANG=32, TILDE=33, ASSIGNMENT=34, LT=35, GT=36, 
		OP_INC=37, OP_DEC=38, OP_AND=39, OP_OR=40, OP_EQ=41, OP_NE=42, OP_LE=43, 
		OP_GE=44, STRING=45, ID=46, INTEGER=47, FLOAT=48, SINGLE_LINE_COMMENT=49, 
		MULTI_LINE_COMMENT=50, WS=51;
	public const int
		COMMENTS_CHANNEL=2;
	public const int
		INTERPOLATED_STRING_MODE=1, INTERPOLATION_MODE=2;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN", "COMMENTS_CHANNEL"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE", "INTERPOLATED_STRING_MODE", "INTERPOLATION_MODE"
	};

	public static readonly string[] ruleNames = {
		"BEGIN", "END", "READ", "WRITE", "PRINT", "CONNECTION", "VAR", "OPEN_BRACE", 
		"CLOSE_BRACE", "INTERPOLATED_STRING_START", "STRING_END", "INTERPOLATION_START", 
		"STRING_CONTENT", "INTERPOLATION_END", "INTERPOLATION_ID", "OPEN_BRACKET", 
		"CLOSE_BRACKET", "OPEN_PARENS", "CLOSE_PARENS", "DOT", "COMMA", "COLON", 
		"SEMICOLON", "PLUS", "MINUS", "ASTERISK", "DIVIDE", "PERCENT", "AMP", 
		"BITWISE_OR", "CARET", "BANG", "TILDE", "ASSIGNMENT", "LT", "GT", "OP_INC", 
		"OP_DEC", "OP_AND", "OP_OR", "OP_EQ", "OP_NE", "OP_LE", "OP_GE", "STRING", 
		"ID", "INTEGER", "FLOAT", "SINGLE_LINE_COMMENT", "MULTI_LINE_COMMENT", 
		"WS"
	};


	public FQLLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public FQLLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'begin'", "'end'", "'read'", "'write'", "'print'", "'connection'", 
		"'var'", null, null, "'$\"'", "'\"'", null, null, null, null, "'['", "']'", 
		"'('", "')'", "'.'", "','", "':'", "';'", "'+'", "'-'", "'*'", "'/'", 
		"'%'", "'&'", "'|'", "'^'", "'!'", "'~'", "'='", "'<'", "'>'", "'++'", 
		"'--'", "'&&'", "'||'", "'=='", "'!='", "'<='", "'>='"
	};
	private static readonly string[] _SymbolicNames = {
		null, "BEGIN", "END", "READ", "WRITE", "PRINT", "CONNECTION", "VAR", "OPEN_BRACE", 
		"CLOSE_BRACE", "INTERPOLATED_STRING_START", "STRING_END", "INTERPOLATION_START", 
		"STRING_CONTENT", "INTERPOLATION_END", "INTERPOLATION_ID", "OPEN_BRACKET", 
		"CLOSE_BRACKET", "OPEN_PARENS", "CLOSE_PARENS", "DOT", "COMMA", "COLON", 
		"SEMICOLON", "PLUS", "MINUS", "ASTERISK", "DIVIDE", "PERCENT", "AMP", 
		"BITWISE_OR", "CARET", "BANG", "TILDE", "ASSIGNMENT", "LT", "GT", "OP_INC", 
		"OP_DEC", "OP_AND", "OP_OR", "OP_EQ", "OP_NE", "OP_LE", "OP_GE", "STRING", 
		"ID", "INTEGER", "FLOAT", "SINGLE_LINE_COMMENT", "MULTI_LINE_COMMENT", 
		"WS"
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

	public override string GrammarFileName { get { return "FQLLexer.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static FQLLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static int[] _serializedATN = {
		4,0,51,307,6,-1,6,-1,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,
		7,5,2,6,7,6,2,7,7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,2,13,
		7,13,2,14,7,14,2,15,7,15,2,16,7,16,2,17,7,17,2,18,7,18,2,19,7,19,2,20,
		7,20,2,21,7,21,2,22,7,22,2,23,7,23,2,24,7,24,2,25,7,25,2,26,7,26,2,27,
		7,27,2,28,7,28,2,29,7,29,2,30,7,30,2,31,7,31,2,32,7,32,2,33,7,33,2,34,
		7,34,2,35,7,35,2,36,7,36,2,37,7,37,2,38,7,38,2,39,7,39,2,40,7,40,2,41,
		7,41,2,42,7,42,2,43,7,43,2,44,7,44,2,45,7,45,2,46,7,46,2,47,7,47,2,48,
		7,48,2,49,7,49,2,50,7,50,1,0,1,0,1,0,1,0,1,0,1,0,1,1,1,1,1,1,1,1,1,2,1,
		2,1,2,1,2,1,2,1,3,1,3,1,3,1,3,1,3,1,3,1,4,1,4,1,4,1,4,1,4,1,4,1,5,1,5,
		1,5,1,5,1,5,1,5,1,5,1,5,1,5,1,5,1,5,1,6,1,6,1,6,1,6,1,7,1,7,1,8,1,8,1,
		9,1,9,1,9,1,9,1,9,1,10,1,10,1,10,1,10,1,11,1,11,1,11,1,11,1,12,4,12,166,
		8,12,11,12,12,12,167,1,13,1,13,1,13,1,13,1,14,1,14,5,14,176,8,14,10,14,
		12,14,179,9,14,1,15,1,15,1,16,1,16,1,17,1,17,1,18,1,18,1,19,1,19,1,20,
		1,20,1,21,1,21,1,22,1,22,1,23,1,23,1,24,1,24,1,25,1,25,1,26,1,26,1,27,
		1,27,1,28,1,28,1,29,1,29,1,30,1,30,1,31,1,31,1,32,1,32,1,33,1,33,1,34,
		1,34,1,35,1,35,1,36,1,36,1,36,1,37,1,37,1,37,1,38,1,38,1,38,1,39,1,39,
		1,39,1,40,1,40,1,40,1,41,1,41,1,41,1,42,1,42,1,42,1,43,1,43,1,43,1,44,
		1,44,5,44,249,8,44,10,44,12,44,252,9,44,1,44,1,44,1,45,1,45,5,45,258,8,
		45,10,45,12,45,261,9,45,1,46,4,46,264,8,46,11,46,12,46,265,1,47,4,47,269,
		8,47,11,47,12,47,270,1,47,1,47,4,47,275,8,47,11,47,12,47,276,1,48,1,48,
		1,48,1,48,5,48,283,8,48,10,48,12,48,286,9,48,1,48,1,48,1,49,1,49,1,49,
		1,49,5,49,294,8,49,10,49,12,49,297,9,49,1,49,1,49,1,49,1,49,1,49,1,50,
		1,50,1,50,1,50,1,295,0,51,3,1,5,2,7,3,9,4,11,5,13,6,15,7,17,8,19,9,21,
		10,23,11,25,12,27,13,29,14,31,15,33,16,35,17,37,18,39,19,41,20,43,21,45,
		22,47,23,49,24,51,25,53,26,55,27,57,28,59,29,61,30,63,31,65,32,67,33,69,
		34,71,35,73,36,75,37,77,38,79,39,81,40,83,41,85,42,87,43,89,44,91,45,93,
		46,95,47,97,48,99,49,101,50,103,51,3,0,1,2,7,3,0,34,34,123,123,125,125,
		3,0,65,90,95,95,97,122,4,0,48,57,65,90,95,95,97,122,3,0,10,10,13,13,34,
		34,1,0,48,57,4,0,10,10,13,13,133,133,8232,8233,3,0,9,10,13,13,32,32,313,
		0,3,1,0,0,0,0,5,1,0,0,0,0,7,1,0,0,0,0,9,1,0,0,0,0,11,1,0,0,0,0,13,1,0,
		0,0,0,15,1,0,0,0,0,17,1,0,0,0,0,19,1,0,0,0,0,21,1,0,0,0,0,33,1,0,0,0,0,
		35,1,0,0,0,0,37,1,0,0,0,0,39,1,0,0,0,0,41,1,0,0,0,0,43,1,0,0,0,0,45,1,
		0,0,0,0,47,1,0,0,0,0,49,1,0,0,0,0,51,1,0,0,0,0,53,1,0,0,0,0,55,1,0,0,0,
		0,57,1,0,0,0,0,59,1,0,0,0,0,61,1,0,0,0,0,63,1,0,0,0,0,65,1,0,0,0,0,67,
		1,0,0,0,0,69,1,0,0,0,0,71,1,0,0,0,0,73,1,0,0,0,0,75,1,0,0,0,0,77,1,0,0,
		0,0,79,1,0,0,0,0,81,1,0,0,0,0,83,1,0,0,0,0,85,1,0,0,0,0,87,1,0,0,0,0,89,
		1,0,0,0,0,91,1,0,0,0,0,93,1,0,0,0,0,95,1,0,0,0,0,97,1,0,0,0,0,99,1,0,0,
		0,0,101,1,0,0,0,0,103,1,0,0,0,1,23,1,0,0,0,1,25,1,0,0,0,1,27,1,0,0,0,2,
		29,1,0,0,0,2,31,1,0,0,0,3,105,1,0,0,0,5,111,1,0,0,0,7,115,1,0,0,0,9,120,
		1,0,0,0,11,126,1,0,0,0,13,132,1,0,0,0,15,143,1,0,0,0,17,147,1,0,0,0,19,
		149,1,0,0,0,21,151,1,0,0,0,23,156,1,0,0,0,25,160,1,0,0,0,27,165,1,0,0,
		0,29,169,1,0,0,0,31,173,1,0,0,0,33,180,1,0,0,0,35,182,1,0,0,0,37,184,1,
		0,0,0,39,186,1,0,0,0,41,188,1,0,0,0,43,190,1,0,0,0,45,192,1,0,0,0,47,194,
		1,0,0,0,49,196,1,0,0,0,51,198,1,0,0,0,53,200,1,0,0,0,55,202,1,0,0,0,57,
		204,1,0,0,0,59,206,1,0,0,0,61,208,1,0,0,0,63,210,1,0,0,0,65,212,1,0,0,
		0,67,214,1,0,0,0,69,216,1,0,0,0,71,218,1,0,0,0,73,220,1,0,0,0,75,222,1,
		0,0,0,77,225,1,0,0,0,79,228,1,0,0,0,81,231,1,0,0,0,83,234,1,0,0,0,85,237,
		1,0,0,0,87,240,1,0,0,0,89,243,1,0,0,0,91,246,1,0,0,0,93,255,1,0,0,0,95,
		263,1,0,0,0,97,268,1,0,0,0,99,278,1,0,0,0,101,289,1,0,0,0,103,303,1,0,
		0,0,105,106,5,98,0,0,106,107,5,101,0,0,107,108,5,103,0,0,108,109,5,105,
		0,0,109,110,5,110,0,0,110,4,1,0,0,0,111,112,5,101,0,0,112,113,5,110,0,
		0,113,114,5,100,0,0,114,6,1,0,0,0,115,116,5,114,0,0,116,117,5,101,0,0,
		117,118,5,97,0,0,118,119,5,100,0,0,119,8,1,0,0,0,120,121,5,119,0,0,121,
		122,5,114,0,0,122,123,5,105,0,0,123,124,5,116,0,0,124,125,5,101,0,0,125,
		10,1,0,0,0,126,127,5,112,0,0,127,128,5,114,0,0,128,129,5,105,0,0,129,130,
		5,110,0,0,130,131,5,116,0,0,131,12,1,0,0,0,132,133,5,99,0,0,133,134,5,
		111,0,0,134,135,5,110,0,0,135,136,5,110,0,0,136,137,5,101,0,0,137,138,
		5,99,0,0,138,139,5,116,0,0,139,140,5,105,0,0,140,141,5,111,0,0,141,142,
		5,110,0,0,142,14,1,0,0,0,143,144,5,118,0,0,144,145,5,97,0,0,145,146,5,
		114,0,0,146,16,1,0,0,0,147,148,5,123,0,0,148,18,1,0,0,0,149,150,5,125,
		0,0,150,20,1,0,0,0,151,152,5,36,0,0,152,153,5,34,0,0,153,154,1,0,0,0,154,
		155,6,9,0,0,155,22,1,0,0,0,156,157,5,34,0,0,157,158,1,0,0,0,158,159,6,
		10,1,0,159,24,1,0,0,0,160,161,5,123,0,0,161,162,1,0,0,0,162,163,6,11,2,
		0,163,26,1,0,0,0,164,166,8,0,0,0,165,164,1,0,0,0,166,167,1,0,0,0,167,165,
		1,0,0,0,167,168,1,0,0,0,168,28,1,0,0,0,169,170,5,125,0,0,170,171,1,0,0,
		0,171,172,6,13,1,0,172,30,1,0,0,0,173,177,7,1,0,0,174,176,7,2,0,0,175,
		174,1,0,0,0,176,179,1,0,0,0,177,175,1,0,0,0,177,178,1,0,0,0,178,32,1,0,
		0,0,179,177,1,0,0,0,180,181,5,91,0,0,181,34,1,0,0,0,182,183,5,93,0,0,183,
		36,1,0,0,0,184,185,5,40,0,0,185,38,1,0,0,0,186,187,5,41,0,0,187,40,1,0,
		0,0,188,189,5,46,0,0,189,42,1,0,0,0,190,191,5,44,0,0,191,44,1,0,0,0,192,
		193,5,58,0,0,193,46,1,0,0,0,194,195,5,59,0,0,195,48,1,0,0,0,196,197,5,
		43,0,0,197,50,1,0,0,0,198,199,5,45,0,0,199,52,1,0,0,0,200,201,5,42,0,0,
		201,54,1,0,0,0,202,203,5,47,0,0,203,56,1,0,0,0,204,205,5,37,0,0,205,58,
		1,0,0,0,206,207,5,38,0,0,207,60,1,0,0,0,208,209,5,124,0,0,209,62,1,0,0,
		0,210,211,5,94,0,0,211,64,1,0,0,0,212,213,5,33,0,0,213,66,1,0,0,0,214,
		215,5,126,0,0,215,68,1,0,0,0,216,217,5,61,0,0,217,70,1,0,0,0,218,219,5,
		60,0,0,219,72,1,0,0,0,220,221,5,62,0,0,221,74,1,0,0,0,222,223,5,43,0,0,
		223,224,5,43,0,0,224,76,1,0,0,0,225,226,5,45,0,0,226,227,5,45,0,0,227,
		78,1,0,0,0,228,229,5,38,0,0,229,230,5,38,0,0,230,80,1,0,0,0,231,232,5,
		124,0,0,232,233,5,124,0,0,233,82,1,0,0,0,234,235,5,61,0,0,235,236,5,61,
		0,0,236,84,1,0,0,0,237,238,5,33,0,0,238,239,5,61,0,0,239,86,1,0,0,0,240,
		241,5,60,0,0,241,242,5,61,0,0,242,88,1,0,0,0,243,244,5,62,0,0,244,245,
		5,61,0,0,245,90,1,0,0,0,246,250,5,34,0,0,247,249,8,3,0,0,248,247,1,0,0,
		0,249,252,1,0,0,0,250,248,1,0,0,0,250,251,1,0,0,0,251,253,1,0,0,0,252,
		250,1,0,0,0,253,254,5,34,0,0,254,92,1,0,0,0,255,259,7,1,0,0,256,258,7,
		2,0,0,257,256,1,0,0,0,258,261,1,0,0,0,259,257,1,0,0,0,259,260,1,0,0,0,
		260,94,1,0,0,0,261,259,1,0,0,0,262,264,2,48,57,0,263,262,1,0,0,0,264,265,
		1,0,0,0,265,263,1,0,0,0,265,266,1,0,0,0,266,96,1,0,0,0,267,269,7,4,0,0,
		268,267,1,0,0,0,269,270,1,0,0,0,270,268,1,0,0,0,270,271,1,0,0,0,271,272,
		1,0,0,0,272,274,5,46,0,0,273,275,7,4,0,0,274,273,1,0,0,0,275,276,1,0,0,
		0,276,274,1,0,0,0,276,277,1,0,0,0,277,98,1,0,0,0,278,279,5,47,0,0,279,
		280,5,47,0,0,280,284,1,0,0,0,281,283,8,5,0,0,282,281,1,0,0,0,283,286,1,
		0,0,0,284,282,1,0,0,0,284,285,1,0,0,0,285,287,1,0,0,0,286,284,1,0,0,0,
		287,288,6,48,3,0,288,100,1,0,0,0,289,290,5,47,0,0,290,291,5,42,0,0,291,
		295,1,0,0,0,292,294,9,0,0,0,293,292,1,0,0,0,294,297,1,0,0,0,295,296,1,
		0,0,0,295,293,1,0,0,0,296,298,1,0,0,0,297,295,1,0,0,0,298,299,5,42,0,0,
		299,300,5,47,0,0,300,301,1,0,0,0,301,302,6,49,3,0,302,102,1,0,0,0,303,
		304,7,6,0,0,304,305,1,0,0,0,305,306,6,50,4,0,306,104,1,0,0,0,12,0,1,2,
		167,177,250,259,265,270,276,284,295,5,5,1,0,4,0,0,5,2,0,0,2,0,6,0,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace FQL.Parser
