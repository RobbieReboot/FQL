using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FQL.Parser
{
    internal class Utils
    {
        public static bool IsNumericTypeBasedOnRefValueType(object t)
        {
            if (t == null) return false;
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

        // converts the Json element into its underlying type held in a dynamic.
        public static dynamic ConvertToDynamic(JsonElement element)
        {
            switch (element.ValueKind)
            {
                case JsonValueKind.Number:
                    var deserialized = element.GetDecimal();

                    if (deserialized <= int.MaxValue && deserialized >= int.MinValue)
                    {
                        return (int)deserialized;
                    }
                    else if (deserialized <= float.MaxValue && deserialized >= float.MinValue)
                    {
                        return (float)deserialized;
                    }
                    else if (deserialized <= double.MaxValue && deserialized >= double.MinValue)
                    {
                        return (double)deserialized;
                    }
                    else
                    {
                        return deserialized;
                    }



                    return element.GetDecimal();
                case JsonValueKind.String:
                    return element.GetString();
                case JsonValueKind.True:
                    return true;
                case JsonValueKind.False:
                    return false;
                case JsonValueKind.Object:
                    var jsonObject = new Dictionary<string, dynamic>();
                    foreach (var property in element.EnumerateObject())
                    {
                        jsonObject.Add(property.Name, ConvertToDynamic(property.Value));
                    }
                    return jsonObject;
                case JsonValueKind.Array:
                    var jsonArray = new List<dynamic>();
                    foreach (var item in element.EnumerateArray())
                    {
                        jsonArray.Add(ConvertToDynamic(item));
                    }
                    return jsonArray;
                default:
                    return null;
            }
        }

        public static string CreateError(ParserRuleContext context, string grammarName, string message)
        {
            return $"{grammarName} ({context.Start.Line},{context.Start.Column}) : {message}";
        }

        public static string PrettyPrintJson(JsonDocument document)
        {
            var options = new JsonWriterOptions
            {
                Indented = true, MaxDepth = 8, SkipValidation = true
            };

            var buffer = new System.Buffers.ArrayBufferWriter<byte>();
            using (var writer = new Utf8JsonWriter(buffer, options))
            {
                document.WriteTo(writer);
            }

            return System.Text.Encoding.UTF8.GetString(buffer.WrittenSpan);
        }
    }
}
