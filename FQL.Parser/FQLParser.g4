parser grammar FQLParser;

options { tokenVocab=FQLLexer; }

// Parser rules


program
    : statement*  EOF
    ;


statement
    : varDeclaration
    | printStatement
    | connectionString
    | SINGLE_LINE_COMMENT
    | MULTI_LINE_COMMENT
    ;

varDeclaration: VAR SYMBOL EQUALS expression SEMI;

expression
    : STRING            # stringLiteral 
    | INT               # intLiteral
    | SYMBOL            # var
    ;

printStatement
    : PRINT printParams SEMI
    ;

printParams
    : STRING_INTERPOLATION      # printInterpolationString
    | STRING                    # printStringLiteral
    | SYMBOL                    # printSymbolReference
    ;


connectionString
    : CONNECTION STRING SEMI
    ;


