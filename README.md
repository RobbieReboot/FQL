# FQL - Fleet Query Language


## Getting started

There are two methods for building ANTLR parsers. 

### Manual method:
This method allows more control form the command line.
1. Download and install [Java](https://www.java.com/download/ie_manual.jsp)
1. Download the Antlr-4 Tool from the [Antlr Download page](https://www.antlr.org/download.html)  
1. move the Antlr4 jar file to a project sub folder, usually an `antlr` folder within the project.
1. add a post-build step to execute Antlr and create the lexer & parsers  
    e.g.:  
```Powershell
    java -jar $(SolutionDir)antlr\antlr-4.13.0-complete.jar -o Parser -visitor -Dlanguage=CSharp $(ProjectDir)\YourLexer.g4  
    java -jar $(SolutionDir)antlr\antlr-4.13.0-complete.jar -o Parser -visitor -Dlanguage=CSharp $(ProjectDir)\YourParser.g4"
```    

### Preferred method

Add the [ANTLR4BuildTasks](https://github.com/kaby76/Antlr4BuildTasks/tree/master) from Nuget for VS2022  
Do not install any other Antlr Build package, including the 'official' tooling. It's 3 years out of date and no longer updated.

### Using VSCode
VSCode has a handy extension for syntax highlighting & graphing tools to inspect the Antlr4 Grammars.
```
ANTLR4 grammar syntax support
v2.3.1
Mike Lischke
```

### FQL Usage

```
// Example code so far
VAR MyVar1 = "Hello";
VAR MyVar2 = "World";
VAR xxx = MyVar2;
PRINT $"String interpolation says {MyVar1} {xxx}";
PRINT "Hello World String!";
PRINT MyVar1;

// Single line comment for connection stirng.

CONNECTION "Data Source=.\;Integrated Security=SSPI;Initial Catalog=sqldb-daprservice;MultipleActiveResultSets=True;Encrypt=false;TrustServerCertificate=true";

VAR receiptCount = COUNT()


/*

MULTI line comment for local Database connection details.

Creating Database                       : sqldb-receipt-service
Creating User                           : dapruser
- Password                              : ySwp0aGAmhI1jns0wgkb5zmH9iuW7AMQ
Creating Server user                    : dapruser
Setting db_owner                        : dapruser

*/
```


### Documentation

Read the [getting started documentation](https://github.com/antlr/antlr4/blob/master/doc/getting-started.md) on github, or the [MEGA tutorial](https://tomassetti.me/antlr-mega-tutorial/) on the language engineering website [Strumenta](https://strumenta.com/).

## Books
Get [The Definitive ANTLR 4 Reference](https://www.amazon.co.uk/Definitive-ANTLR-4-Reference/dp/1934356999/ref=sr_1_1?crid=18NZ4S6UJ440R&keywords=ANTLR&qid=1691662200&sprefix=antlr%2Caps%2C71&sr=8-1) from Amazon








