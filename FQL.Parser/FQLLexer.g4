lexer grammar FQLLexer;

channels { COMMENTS_CHANNEL }

// Statements

BEGIN
	: 'begin'
	;
END
	: 'end'
	;

READ
	: 'read'
	;
WRITE
	: 'write'
	;

PRINT
	: 'print'
	;
CONNECTION
	: 'connection'
	;

VAR
	: 'var'
	;
IF
	: 'if'
	;
ELSE
	: 'else'
	;
RETURN
	: 'return'
	;
TRUE
	: 'true'
	;
FALSE
	: 'false'
	;


// Interpolation String
INTERPOLATED_STRING_START   : '$"' -> pushMode(INTERPOLATED_STRING_MODE) ;

mode INTERPOLATED_STRING_MODE;		// REMEMBER : THIS IS A NEW LEXER CONTEXT - ALL LEXER RULES HAVE GONE!

STRING_END                 : '"' -> popMode ;
INTERPOLATION_START        : '{' -> pushMode(INTERPOLATION_MODE) ;
STRING_CONTENT             : ~["{}]+ ;  // Everything except " and { and }

mode INTERPOLATION_MODE;

INTERPOLATION_END          : '}' -> popMode ;

INTERPOLATION_ID           : [a-zA-Z_][a-zA-Z0-9_]* ;  // For ID recognition within interpolation

// ID token already captures the variable name pattern, so we don't need a separate VAR_NAME rule.
mode DEFAULT_MODE;

OPEN_BRACKET:				'[';
CLOSE_BRACKET:				']';
OPEN_PARENS:				'(';
CLOSE_PARENS:				')';
OPEN_BRACE:					'{';
CLOSE_BRACE:				'}';
DOT:						'.';
COMMA:						',';
COLON:						':';
SEMICOLON:					';';
PLUS:						'+';
MINUS:						'-';
ASTERISK:					'*';
DIVIDE:						'/';
PERCENT:					'%';
AMP:						'&';
BITWISE_OR:					'|';
CARET:						'^';
BANG:						'!';
TILDE:						'~';
ASSIGNMENT:					'=';
LT:							'<';
GT:							'>';
OP_INC:						'++';
OP_DEC:						'--';
OP_AND:						'&&';
OP_OR:						'||';
OP_EQ:						'==';
OP_NE:						'!=';
OP_LE:						'<=';
OP_GE:						'>=';


STRING
	: '"' (~["\r\n])* '"'
	;

ID
	: [a-zA-Z_][a-zA-Z0-9_]*
	;

INTEGER
   : ('0' .. '9')+
   ;
FLOAT
	: [0-9]+ '.' [0-9]+ 
	;

SINGLE_LINE_COMMENT
	: '//' ~[\r\n\u0085\u2028\u2029]*  -> channel(COMMENTS_CHANNEL)
	;

MULTI_LINE_COMMENT
	: '/*' .*? '*/' -> channel(COMMENTS_CHANNEL)
	;
WS                         
	: [ \r\n\t] -> skip 
	;
