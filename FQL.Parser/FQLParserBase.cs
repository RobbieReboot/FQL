using System;
using System.Collections.Generic;
using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

public abstract class FQLParserBase : Parser
{
    protected FQLParserBase(ITokenStream input)
        : base(input)
    {
    }

    protected FQLParserBase(ITokenStream input, TextWriter output, TextWriter errorOutput)
        : base(input, output, errorOutput)
    {
    }


}