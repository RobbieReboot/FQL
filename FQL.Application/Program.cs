using Antlr4.Runtime;
using System.Text;
using FQL;
using FQL.Parser;
using Microsoft.Extensions.DependencyInjection;

//"Data Source=.\;Integrated Security=SSPI;Initial Catalog=FormsMiddlewareDevUAT;MultipleActiveResultSets=True;app=LINQPad;Encrypt=true;TrustServerCertificate=true"
//var grammarName = "FQLJsonTest.fql";
var grammarName = "FQLJsonDoc.fql";

var scriptExec = new FQLScript(grammarName);
var result = scriptExec.Execute();


Console.WriteLine($"Execution {(result==true ? "Succeeded" : "Failed") }");


