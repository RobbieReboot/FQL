lexer grammar FQLLexer;

channels { COMMENTS_CHANNEL, DIRECTIVE }


//Commands

BEGIN
	: 'BEGIN'
	;
END
	: 'END'
	;

READ
	: 'READ'
	;
WRITE
	: 'WRITE'
	;

PRINT
	: 'PRINT'
	;
CONNECTION
	: 'CONNECTION'
	;

VAR
	: 'var'
	;

//B.1.9 Operators And Punctuators
OPEN_BRACE:               '{';
CLOSE_BRACE:              '}';



// Interpolation String
INTERPOLATED_STRING_START   : '$"' -> pushMode(INTERPOLATED_STRING_MODE) ;

mode INTERPOLATED_STRING_MODE;

STRING_END                 : '"' -> popMode ;
INTERPOLATION_START        : '{' -> pushMode(INTERPOLATION_MODE) ;
STRING_CONTENT             : ~["{}]+ ;  // Everything except " and { and }

mode INTERPOLATION_MODE;

INTERPOLATION_END          : '}' -> popMode ;
INTERPOLATION_ID           : [a-zA-Z_][a-zA-Z0-9_]* ;  // ID recognition within interpolation

// ID token already captures the variable name pattern, so we don't need a separate VAR_NAME rule.
mode DEFAULT_MODE;





OPEN_BRACKET:             '[';
CLOSE_BRACKET:            ']';
OPEN_PARENS:              '(';
CLOSE_PARENS:             ')';
DOT:                      '.';
COMMA:                    ',';
COLON:                    ':';
SEMICOLON:                ';';
PLUS:                     '+';
MINUS:                    '-';
STAR:                     '*';
DIV:                      '/';
PERCENT:                  '%';
AMP:                      '&';
BITWISE_OR:               '|';
CARET:                    '^';
BANG:                     '!';
TILDE:                    '~';
ASSIGNMENT:               '=';
LT:                       '<';
GT:                       '>';
INTERR:                   '?';
DOUBLE_COLON:             '::';
OP_COALESCING:            '??';
OP_INC:                   '++';
OP_DEC:                   '--';
OP_AND:                   '&&';
OP_OR:                    '||';
OP_PTR:                   '->';
OP_EQ:                    '==';
OP_NE:                    '!=';
OP_LE:                    '<=';
OP_GE:                    '>=';
OP_ADD_ASSIGNMENT:        '+=';
OP_SUB_ASSIGNMENT:        '-=';
OP_MULT_ASSIGNMENT:       '*=';
OP_DIV_ASSIGNMENT:        '/=';
OP_MOD_ASSIGNMENT:        '%=';
OP_AND_ASSIGNMENT:        '&=';
OP_OR_ASSIGNMENT:         '|=';
OP_XOR_ASSIGNMENT:        '^=';
OP_LEFT_SHIFT:            '<<';
OP_LEFT_SHIFT_ASSIGNMENT: '<<=';
OP_COALESCING_ASSIGNMENT: '??=';
OP_RANGE:                 '..';




STRING
	: '"' (~["\r\n])* '"'
	;

ID
	: [a-zA-Z_][a-zA-Z0-9_]*
	;

NUMBER
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
