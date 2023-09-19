grammar Source;

// Parser Rules
sourceFile: statement* EOF;

statement: assignment
         | commandBlock
         ;

assignment: CONST ID EQUAL expression ;

commandBlock: ID '[' expression ']:' command* END ;

command: ID EQUAL expression ;

function: ID '(' exprList ')' ;

exprList: (expression (',' expression)*)? ;

expression: INT       #intExpression
          | STRING    #stringExpression
          | ID        #idExpression
          | function  #functionExpression
          ;

// Lexer Rules
STRING        : '"' .*? '"';
CONST         : 'const' ;
END           : 'end' ;
EQUAL         : '=' ;
ID            : LETTER (LETTER | DIGIT | '_')*  ;
INT           : DIGIT+;
LINE_COMMENT  : '//' .*? '\n' -> skip ;
COMMENT       : '/*' .*? '*/' -> skip ;
WS            : [ \t\n\r]+ -> skip ;

fragment
LETTER  : [a-zA-Z_] ;

fragment
DIGIT   : [0-9] ;