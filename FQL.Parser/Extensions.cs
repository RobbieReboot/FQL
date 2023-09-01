using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FQL.Parser
{
    internal static class Extensions
    {
        public static string Elipsize(this string input, int maxLength, bool elipsisAtBegining = false)
        {
            var result = input;
            if (input.Length <= maxLength) return result;
            if (elipsisAtBegining)
            {
                result = input.Substring(result.Length - maxLength + 3, maxLength - 3);
                result = "..." + result;
            }
            else
            {
                result = input.Substring(0, maxLength - 3);
                result = result + "...";
            }
            return result;
        }
    }
}
