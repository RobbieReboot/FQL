using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FQL.Parser
{
    internal class Utils
    {
        public static bool IsNumericTypeBasedOnRefValueType(object t)
        {
            Type type = t.GetType();
            // Check if it's a value type, but not an enum.
            if (!type.IsValueType || type.IsEnum)
            {
                return false;
            }

            // Exclude bool its a primitive but doesn't do arithemtic ops
            if (type == typeof(bool))
            {
                return false;
            }

            // Exclude commonly used structs like DateTime and TimeSpan.
            if (type == typeof(DateTime) || type == typeof(TimeSpan))
            {
                return false;
            }

            // Check if it's one of the primitive types this includes most numeric types).
            if (type.IsPrimitive)
            {
                return true;
            }

            // Check for decimal, which isn't considered a primitive but still can do aritmetic
            if (type == typeof(decimal))
            {
                return true;
            }

            // At this point, it's a struct, but not one of the common non-numeric structs we know so bail.
            return false;
        }

    }
}
