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
   : id = identifier                                        # IdentifierAtom
   | b = boolean                                            # BoolAtom
   | f = FLOAT                                              # FloatAtom
   | d = DOUBLE                                             # DoubleAtom
   | m = DECIMAL                                            # DecimalAtom
   | i = integer                                            # IntAtom
   | OPEN_PARENS expression CLOSE_PARENS                    # ParenExpr
   | string                                                 # stringAtom
   | OPEN_PARENS? complexAtomPart CLOSE_PARENS?             # complexAtom
   | jsonDocument                                           # JsonDoc
   ;

complexAtomPart
    : callStatement                                         # FunctionCallAtom 
    | getStatement                                          # GetAtom
    | objectAccess                                          # ObjectAccessAtom
    ;

objectAccess
    : jsonPath
    ;

jsonPath 
    :   segment (DOT segment)*
    ;

segment
    : ID (OPEN_BRACKET (INTEGER | STRING) CLOSE_BRACKET)?
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

jsonDocument
    : JSON_DOC_START JSON_DOC_CONTENT JSON_DOC_END
    ;

stringLiteral
    : STRING
    ;

interpolatedString 
    : INTERPOLATED_STRING_START ( STRING_CONTENT | interpolation )* STRING_END 
    ;

// Remember the INTERPOLATION_ID is in a different lexer mode, so it doesn't compete
interpolation     
    : INTERPOLATION_START INTERPOLATION_ID INTERPOLATION_END 
    ;

