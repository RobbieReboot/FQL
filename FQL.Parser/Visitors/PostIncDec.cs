namespace FQL.Parser;

public partial class FQLVisitor
{
    public object VisitPostIncDecStatement(FQLParser.PostIncDecIdentContext context)
    {
        var name = context.ID().GetText();
        var obj = _stateManager.SymbolTable[name];
        var retVal = obj;           //save value BEFORE we inc/dec

        if (context.pre is { Text: "++" })
        {
            if (obj is byte)
                obj = (byte)obj + 1;
            if (obj is sbyte)
                obj = (sbyte)obj + 1;
            if (obj is short)
                obj = (short)obj + 1;
            if (obj is ushort)
                obj = (ushort)obj + 1;
            if (obj is int)
                obj = (int)obj + 1;
            if (obj is uint)
                obj = (uint)obj + 1;
            if (obj is long)
                obj = (long)obj + 1;
            if (obj is ulong)
                obj = (ulong)obj + 1;
            if (obj is float)
                obj = (float)obj + 1;
            if (obj is double)
                obj = (double)obj + 1;
            if (obj is decimal)
                obj = (decimal)obj + 1;

            _stateManager.SymbolTable[name] = obj;
            return obj;
        }
        if (context.pre is { Text: "--" })
        {
            if (obj is byte)
                obj = (byte)obj - 1;
            if (obj is sbyte)
                obj = (sbyte)obj - 1;
            if (obj is short)
                obj = (short)obj - 1;
            if (obj is ushort)
                obj = (ushort)obj - 1;
            if (obj is int)
                obj = (int)obj - 1;
            if (obj is uint)
                obj = (uint)obj - 1;
            if (obj is long)
                obj = (long)obj - 1;
            if (obj is ulong)
                obj = (ulong)obj - 1;
            if (obj is float)
                obj = (float)obj - 1;
            if (obj is double)
                obj = (double)obj - 1;
            if (obj is decimal)
                obj = (decimal)obj - 1;
            _stateManager.SymbolTable[name] = obj;
            return obj;             // YES I KNOW THIS ISN'T TRUE POST INC/DECREMENT.
        }

        if (context.post is { Text: "++" })
        {
            if (obj is byte)
                obj = (byte)obj + 1;
            if (obj is sbyte)
                obj = (sbyte)obj + 1;
            if (obj is short)
                obj = (short)obj + 1;
            if (obj is ushort)
                obj = (ushort)obj + 1;
            if (obj is int)
                obj = (int)obj + 1;
            if (obj is uint)
                obj = (uint)obj + 1;
            if (obj is long)
                obj = (long)obj + 1;
            if (obj is ulong)
                obj = (ulong)obj + 1;
            if (obj is float)
                obj = (float)obj + 1;
            if (obj is double)
                obj = (double)obj + 1;
            if (obj is decimal)
                obj = (decimal)obj + 1;

            _stateManager.SymbolTable[name] = obj;
            return retVal;
        }
        if (context.post is { Text: "--" })
        {
            if (obj is byte)
                obj = (byte)obj - 1;
            if (obj is sbyte)
                obj = (sbyte)obj - 1;
            if (obj is short)
                obj = (short)obj - 1;
            if (obj is ushort)
                obj = (ushort)obj - 1;
            if (obj is int)
                obj = (int)obj - 1;
            if (obj is uint)
                obj = (uint)obj - 1;
            if (obj is long)
                obj = (long)obj - 1;
            if (obj is ulong)
                obj = (ulong)obj - 1;
            if (obj is float)
                obj = (float)obj - 1;
            if (obj is double)
                obj = (double)obj - 1;
            if (obj is decimal)
                obj = (decimal)obj - 1;
            _stateManager.SymbolTable[name] = obj;
            return retVal;
        }
        throw new ArgumentException("Unsupported numeric type", nameof(obj));
    }
}