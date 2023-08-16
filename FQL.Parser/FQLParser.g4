parser grammar FQLParser;
options { tokenVocab=FQLLexer; }


// Parser rules
program
   : BEGIN statements END EOF
   ;

statements
   : statements statement
   | statement
   ;

statement
   : assignment SEMICOLON   
   | readStatement SEMICOLON    
   | writeStatement SEMICOLON   
//   | printStatement SEMICOLON
   ;

//printStatement
//    : PRINT printParams
//    ;

//printParams
//    : STRING_INTERPOLATION      # printInterpolationString
//    | STRING                    # printStringLiteral
//    | identifier                # printSymbolReference
//    ;

assignment
   : VAR identifier ASSIGNMENT expression
   ;

readStatement
   : READ identifierList
   ;

writeStatement
   : WRITE expressionList
   ;

identifierList
   : identifierList COMMA identifier
   | identifier
   ;

expressionList
   : expressionList COMMA expression
   | expression
   ;

expression
   : factor operator expression # ComplexFactor                //Use left recursion to avoid Null on expression recursive Visit
   | factor                     # SimpleFactor
   ;

factor
   : id = identifier            # IdentifierFactor
   | str = STRING               # StringFactor
   | i = integer                # IntFactor
   | OPEN_PARENS expression CLOSE_PARENS # ParenExpr
   ;

integer
   : MINUS? NUMBER
   ;

operator
   : PLUS
   | MINUS
   ;

identifier
   : ID
   ;

string
    : STRING
//    | STRING_INTERPOLATION
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
