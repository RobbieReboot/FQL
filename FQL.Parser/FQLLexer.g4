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
FUNCTION
	: 'function'
	;
CALL
	: 'call'
	;
DUMP
	: 'dump'
	;
SYMBOLS
	: 'symbols'
	;
CALLSTACK
	: 'callstack'
	;
WHILE
	: 'while'
	;
DO	
	: 'do'
	;
BREAK
	: 'break'
	;
GET
	: 'get'
	;

// Interpolation String
INTERPOLATED_STRING_START   : '$"' -> pushMode(INTERPOLATED_STRING_MODE) ;

mode INTERPOLATED_STRING_MODE;		// REMEMBER : THIS IS A NEW LEXER CONTEXT - ALL LEXER RULES HAVE GONE!

STRING_END                 : '"' -> popMode ;
INTERPOLATION_START        : '{' -> pushMode(INTERPOLATION_MODE) ;
STRING_CONTENT             : ~["{}]+ ;  // Everything except " and { and }
NEWLINE					   : '\r'? '\n';

mode INTERPOLATION_MODE;

INTERPOLATION_END          : '}' -> popMode ;
INTERPOLATION_ID           : [a-zA-Z_][a-zA-Z0-9_]* ;  // For ID recognition within interpolation

// ID token already captures the variable name pattern, so we don't need a separate VAR_NAME rule.
mode DEFAULT_MODE;

//Json document lexing
JSON_DOC_START
	: '@"' -> pushMode(JSON_DOC_MODE)
	;

mode JSON_DOC_MODE;
JSON_DOC_CONTENT
	: ( ~["] | '"' ~[@] )+
	;
JSON_DOC_END
	: '"@' -> popMode
	;

mode DEFAULT_MODE;



OP_INC:						'++';
OP_DEC:						'--';
OP_AND:						'&&';
OP_OR:						'||';


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

fragment EQ: '==';
fragment NE: '!=';
fragment LE: '<=';
fragment GE: '>=';

REL_OP
	: EQ | NE | LT | LE | GT | GE
	;

LT:							'<';
GT:							'>';

/*
STRING 
	: ( '"' ( ESCAPE_SEQUENCE | ~('\\' | '"' | '\r' | '\n' ) | '""' )* '"' )
    | ( '\'' ( ESCAPE_SEQUENCE | ~('\\' | '\'' | '\r' | '\n' ) | '\'\'' )* '\'' );
*/

STRING 
    : ( '"'  (~["\r\n] | '""' | ESCAPE_SEQUENCE | '\r'? '\n')+ '"'
      | '\'' (~['\r\n] | '\'\'' | ESCAPE_SEQUENCE | '\r'? '\n')+ '\'' )
    ;

ESCAPE_SEQUENCE
	: '\\' ('b' | 't' | 'n' | 'f' | 'r' | '"' | '\'' | '\\')
	;
 
ID
	: [a-zA-Z_][a-zA-Z0-9_]*
	;


DOUBLE
	: [0-9]+ '.' [0-9]+ ('D' | 'd')?
	;
FLOAT
	: [0-9]+ '.' [0-9]+ ('F' | 'f')
	;
DECIMAL
	: [0-9]+ '.' [0-9]+ ('M' | 'm')
	;
INTEGER
   : ('0' .. '9')+
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
