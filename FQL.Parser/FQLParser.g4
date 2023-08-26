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
   | callStatement SEMICOLON                    //NO keyword, just func();
   | dumpStatement
   | whileLoop
   | doWhileLoop SEMICOLON
   | breakStatement SEMICOLON
   | getStatement SEMICOLON
   ;

getStatement
    : GET OPEN_PARENS getParams CLOSE_PARENS
    ;
getParams
    : expression
    ;

breakStatement
    : BREAK 
    ;
printStatement
    : PRINT printParams
    ;
identifierOrString
    : string
    | identifier
    ;
printParams
    : string                                                # printString
    | identifier                                            # printIdentifier
    ;

assignment
   : ass=VAR? identifier ASSIGNMENT ( expression | string | callStatement )
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
    : IF OPEN_PARENS boolExpression CLOSE_PARENS OPEN_BRACE statements CLOSE_BRACE (ELSE OPEN_BRACE statements CLOSE_BRACE)?
    ;

return
    : RETURN returnParams? SEMICOLON
    ;
returnParams
    : expression
    | callStatement
    | stringLiteral
    ;

functionDefinition
    : FUNCTION identifier OPEN_PARENS paramList? CLOSE_PARENS OPEN_BRACE statements CLOSE_BRACE
    ;
paramList
    : identifier (COMMA identifier)*
    ;

callStatement
    : identifier OPEN_PARENS callParamList? CLOSE_PARENS 
    ;

callParamList 
    : expression (COMMA expression)*
    ;

dumpStatement
    : DUMP ( CALLSTACK | SYMBOLS) SEMICOLON
    ;

whileLoop 
    : WHILE OPEN_PARENS boolExpression CLOSE_PARENS OPEN_BRACE statements CLOSE_BRACE
    ;
doWhileLoop 
    : DO OPEN_BRACE statements CLOSE_BRACE WHILE OPEN_PARENS boolExpression CLOSE_PARENS
    ;


// Boolean expression logic rules for if and looping constructs.
boolExpression 
    : boolTerm (OP_OR boolTerm)*
    ;

boolTerm
    : boolFactor (OP_AND boolFactor)*
    ;

boolFactor
    : BANG boolFactor
    | relationalExpr
    | boolLiteral
    | OPEN_PARENS boolExpression CLOSE_PARENS
    ;

boolLiteral 
    : TRUE | FALSE 
    ;

relationalExpr 
    : expression REL_OP expression 
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
    : mulDivExpr (( PLUS | MINUS ) mulDivExpr)*             # AdditiveExpr
    ;

mulDivExpr
    : powExpr ((ASTERISK | DIVIDE) powExpr)*                # MultiplicativeExpr
    ;
    
powExpr
    : atom (CARET powExpr)?                                 # ExponentationExpr
    ;

atom
   : b = boolean                                            # BoolAtom
   | i = integer                                            # IntAtom
   | f = FLOAT                                              # FloatAtom
   | OPEN_PARENS? complexAtomPart CLOSE_PARENS?             # complexAtom
   | OPEN_PARENS expression CLOSE_PARENS                    # ParenExpr
   | string                                                 # stringAtom
   | id = identifier                                        # IdentifierAtom
   ;

complexAtomPart
    : callStatement                                         # FunctionCallAtom 
    | getStatement                                          # GetAtom
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
   : ID                                                     # ident
   | pre=(OP_INC | OP_DEC)? ID post=(OP_INC | OP_DEC)?      # postIncDecIdent
   ;

string
    : interpolatedString                                    # InterpolationString
    | stringLiteral                                         # StrLiteral
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

