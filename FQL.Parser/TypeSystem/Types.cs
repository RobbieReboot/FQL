using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FQL.Parser.TypeSystem
{
    abstract class Result
    {
    }

    class IntegerResult : Result
    {
        public int Value { get; }

        public IntegerResult(int value)
        {
            Value = value;
        }
        public static implicit operator int(IntegerResult intResult)
        {
            return intResult.Value;
        }
    }

    class DoubleResult : Result
    {
        public double Value { get; }

        public DoubleResult(double value)
        {
            Value = value;
        }
        public static implicit operator double(DoubleResult doubleResult)
        {
            return doubleResult.Value;
        }
    }
}
