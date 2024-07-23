# FQL - Fleet Query Language

## A minimal DSL 
Originally I wrote this in my spare time - it's a Turning complete Domain Specific Language for an in application language for our fleet application, FleetWave.  
There are currently NO domain specific or FleetWave specific parts in this public version, its here just as a sample of my skills with Antlr - grammars and parsers. (It's been over a decade since I did my last Antlr parser, so the code may be a bit rusty!)

## Feature set so far :
* Conditionals
* Parameterised stack based functions calls
* Closures
* Full recursive descent expression evaluate, including variables
* SQL Server connections and queries
* Looping, Do While & While statements
* Http connection & Get operations
* Json document & Json Path 
* print statements with string interpolation
* single line & multi line comments
* others...

There are partial implementations of many of the visitor classes that didn't get completed, like more SQL statements or HTTP verbs. This really is a work in progress.

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

### Exampl FQL Usage

```
// Example code 
var myval = 1;

if ( myval == 1 ) {
	print "If is TRUE!"; 
	return true;
	print "UNREACHABLE - SHOULDN'T DISPLAY! (but should show unreachable code warning)";
}
else
{
	print "if is FALSE!";
}

var MyVar1 = (5+4)+10;
var MyVar2 = "Hello";
var MyVar3 = "World";
var MyVar4 = $"Interpolated : {MyVar2}, {MyVar3}";

print $"String interpolation says {MyVar2} {MyVar3}";
print MyVar4;

var database = "sqldb-daprservice";

// Single line comment for connection string.

connection $"Data Source=.\;Integrated Security=SSPI;Initial Catalog={database};MultipleActiveResultSets=True;Encrypt=false;TrustServerCertificate=true";

// do some db commands

/* MULTI line comment for local Database connection details.
Database                       : sqldb-test
User                           : dapruser
Password                       : XXXX
*/

print $"Connection String = {connection}";		// Auto creates internal symbol for connection string.

/*
Sample from Health endpoint return.
{
    "status": "Healthy",
    "totalDuration": "00:00:00.0322611",
    "entries": {
        "FQLService liveness": {
            "data": {},
            "description": "Service execution is healthy.",
            "duration": "00:00:00.0306582",
            "status": "Healthy",
            "tags": [
                "web-service-check"
            ]
        },
        "sql-server-connection-check": {
            "data": {},
            "description": "The SQL server Connection is healthy.",
            "duration": "00:00:00.0000584",
            "status": "Healthy",
            "tags": [
                "sql-connection-check"
            ]
        },
    }
}
*/

// Call web service healthcheck endpoint & JSON access 

healthCheck = get("https://localhost:2000/health-check");

h1 = healthCheck.entries["FQLService liveness"].description;
print $"Health FQLService liveness description :  {h1}";

h1 = healthCheck.entries["FQLService liveness"].tags[0];
print $"{h1}";
h2 = healthCheck.entries["FQLServiceContext Custom Check"].tags[0];
print $"{h2}";

print "Done.";
```

### Antlr Documentation

Read the [getting started documentation](https://github.com/antlr/antlr4/blob/master/doc/getting-started.md) on github, or the [MEGA tutorial](https://tomassetti.me/antlr-mega-tutorial/) on the language engineering website [Strumenta](https://strumenta.com/).

## Books
Get [The Definitive ANTLR 4 Reference](https://www.amazon.co.uk/Definitive-ANTLR-4-Reference/dp/1934356999/ref=sr_1_1?crid=18NZ4S6UJ440R&keywords=ANTLR&qid=1691662200&sprefix=antlr%2Caps%2C71&sr=8-1) from Amazon








