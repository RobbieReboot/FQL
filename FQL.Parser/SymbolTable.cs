using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FQL.Parser
{
    /// <summary>
    /// Simple symbol table for parser variables.
    /// </summary>
    public class SymbolTable
    {
        private readonly Dictionary<string, object?> _symbols = new(128);

        public SymbolTable() { }

        public object? this[string key]
        {
            get => _symbols[key];
            set => _symbols[key] = value;
        }

        public void Add(string key, object? value) => _symbols.Add(key,value);

        public bool TryGetValue(string varName, out object? o) => _symbols.TryGetValue( varName, out o);

        public void Clear() => _symbols.Clear();

        public void Dump()
        {
            foreach (var symbol in _symbols)
            {
                Console.WriteLine($"{symbol.Key} : {symbol.Value}");
            }
        }
    }
}
