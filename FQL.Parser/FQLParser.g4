parser grammar FQLParser;
options { tokenVocab=FQLLexer; }

// Parser rules
program
   : statements EOF
   ;

//
// Statements 
//

statements
   : statements statement
   | statement
   ;

statement
   : assignment SEMICOLON   
   | readStatement SEMICOLON    
   | writeStatement SEMICOLON   
   | printStatement SEMICOLON
   | connectionStatement SEMICOLON
   ;

printStatement
    : PRINT printParams
    ;

printParams
    : string                    # printString
    | identifier                # printIdentifier
    ;

assignment
   : VAR identifier ASSIGNMENT expression
   ;

readStatement
   : READ identifierList
   ;

writeStatement
   : WRITE expressionList
   ;

connectionStatement
    : CONNECTION string
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
   | str = string               # StringFactor
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
    : interpolatedString    # InterpolationString
    | STRING                # StringLiteral
    ;

interpolatedString 
    : INTERPOLATED_STRING_START ( STRING_CONTENT | interpolation )* STRING_END 
    ;

interpolation     
    : INTERPOLATION_START INTERPOLATION_ID INTERPOLATION_END 
    ;

