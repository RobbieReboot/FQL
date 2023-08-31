using System.ComponentModel;

namespace FQL.Parser;

public enum FQLErrorSeverity
{
    [Description("Debug level information")]
    Debug,
    [Description("Informational.")]
    Info,
    [Description("Warning. May need further investigation.")]
    Warning,
    [Description("Error. Needs investigation, may prevent correct execution.")]
    Error,
    [Description("Fatal error halt execution immediately.")]
    Fatal
}