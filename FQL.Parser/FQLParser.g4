parser grammar FQLParser;
options { tokenVocab=FQLLexer; superClass = FQLParserBase;  }
//options { tokenVocab=FQLLexer;  }

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
   | if 
   | return 
   | functionDefinition
   | callStatement
   | dumpStatement
   ;

printStatement
    : PRINT printParams
    ;

printParams
    : string                                    # printString
    | identifier                                # printIdentifier
    ;

assignment
   : VAR identifier ASSIGNMENT ( expression | string | callStatement )
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

if
    : IF OPEN_PARENS expression OP_EQ expression CLOSE_PARENS OPEN_BRACE statements CLOSE_BRACE (ELSE OPEN_BRACE statements CLOSE_BRACE)?
    ;

return
    : RETURN returnParams? SEMICOLON
    ;
returnParams
    : expression
    | stringLiteral
    ;

functionDefinition
    : FUNCTION identifier OPEN_PARENS paramList? CLOSE_PARENS OPEN_BRACE statements CLOSE_BRACE
    ;
paramList
    : identifier (COMMA identifier)*
    ;

callStatement
    : CALL identifier OPEN_PARENS callParamList? CLOSE_PARENS SEMICOLON
    ;

callParamList 
    : identifier (COMMA identifier)*
    ;

dumpStatement
    : DUMP ( CALLSTACK | SYMBOLS) SEMICOLON
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
   : b = boolean                                # BoolFactor
   | i = integer                                # IntFactor
   | f = FLOAT                                   # FloatFactor
   | OPEN_PARENS expression CLOSE_PARENS        # ParenExpr
   | id = identifier                            # IdentifierFactor
   ;
boolean
    : ( TRUE | FALSE )
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
    | stringLiteral                             # StrLiteral
    ;

stringLiteral
    : STRING
    ;

interpolatedString 
    : INTERPOLATED_STRING_START ( STRING_CONTENT | interpolation )* STRING_END 
    ;

interpolation     
    : INTERPOLATION_START INTERPOLATION_ID INTERPOLATION_END 
    ;

