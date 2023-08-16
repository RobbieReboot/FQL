parser grammar FQLParser;
options { tokenVocab=FQLLexer; }


// Parser rules
program
   : BEGIN statements END EOF
   ;

statements
   : statements stmt
   | stmt
   ;

stmt
   : assign_stmt SEMICOLON
   | read_stmt SEMICOLON
   | write_stmt SEMICOLON
   ;

assign_stmt
   : VAR ident ASSIGNMENT expr
   ;

read_stmt
   : READ id_list
   ;

write_stmt
   : WRITE expr_list
   ;

id_list
   : id_list COMMA ident
   | ident
   ;

expr_list
   : expr_list COMMA expr
   | expr
   ;

expr
   : factor op expr     # OpExpr                //Use left recursion to avoid Null on expr recursive Visit
   | factor             # SimpleFactor
   ;

factor
   : id = ident     # IdentFactor
   | str = STRING   # StringFactor
   | i = integer    # IntFactor
   | OPEN_PARENS expr CLOSE_PARENS # ParenExpr
   ;

integer
   : MINUS? NUMBER
   ;

op
   : PLUS
   | MINUS
   ;

ident
   : ID
   ;














/*

program
    : statement*  EOF
    ;


statement
    : varDeclaration
    | printStatement
    | connectionString
    | SINGLE_LINE_COMMENT
    | DELIMITED_COMMENT
    ;

varDeclaration: VAR SYMBOL EQUALS expression SEMICOLON;

expression
    : STRING            # stringLiteral 
    | INT               # intLiteral
    | SYMBOL            # var
    ;

printStatement
    : PRINT printParams SEMICOLON
    ;

printParams
    : STRING_INTERPOLATION      # printInterpolationString
    | STRING                    # printStringLiteral
    | SYMBOL                    # printSymbolReference
    ;


connectionString
    : CONNECTION STRING SEMI
    ;

*/
