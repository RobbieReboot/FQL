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
    : string                                    # printString
    | identifier                                # printIdentifier
    ;

assignment
   : VAR identifier ASSIGNMENT ( expression | string )
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
    : mulDivExpr (( PLUS | MINUS ) mulDivExpr)*  # AdditiveExpr
    ;

mulDivExpr
    : powExpr ((ASTERISK | DIVIDE) powExpr)*   # MultiplicativeExpr
    ;
    
powExpr
    : atom (CARET powExpr)?                    # ExponentationExpr
    ;

atom
   : id = identifier                            # IdentifierFactor
   //| str = string                               # StringFactor
   | i = integer                                # IntFactor
   | f = FLOAT                                   # FloatFactor
   | OPEN_PARENS expression CLOSE_PARENS        # ParenExpr
   ;

integer
   : MINUS? INTEGER
   ;

operator
   : PLUS
   | MINUS
   ;

identifier
   : ID
   ;

string
    : interpolatedString                        # InterpolationString
    | STRING                                    # StringLiteral
    ;

interpolatedString 
    : INTERPOLATED_STRING_START ( STRING_CONTENT | interpolation )* STRING_END 
    ;

interpolation     
    : INTERPOLATION_START INTERPOLATION_ID INTERPOLATION_END 
    ;

