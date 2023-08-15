lexer grammar FQLLexer;


SINGLE_LINE_COMMENT: '//' ~('\n')* '\n'?;
VAR: 'VAR';
PRINT: 'PRINT';
CONNECTION: 'CONNECTION';
EQUALS: '=';
SEMI: ';';
LPAREN: '(';
RPAREN: ')';
COUNT: 'COUNT';
LCURLY: '{';
RCURLY: '}';
INT: [0-9]+ ;
MULTI_LINE_COMMENT: '/*' .*? '*/' ;


SYMBOL: [a-zA-Z_][a-zA-Z0-9_]*;

STRING: '"' (~["\r\n])* '"';
STRING_INTERPOLATION: '$"' (ESC | ~["])* '"';
ESC: '{' SYMBOL '}';

WS: [ \t\r\n]+ -> skip;
