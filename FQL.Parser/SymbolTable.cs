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
        private Stack<Dictionary<string, object?>> _scopedSymbols = new Stack<Dictionary<string, object?>>();
        private Dictionary<string, object?> _currentScope => _scopedSymbols.Peek();
        public Dictionary<string, object?> CurrentScope => _currentScope;
        public Dictionary<string, object?> GlobalScope => _scopedSymbols.First();

        public SymbolTable()
        {
            //Create default scope
            Push();
        }

        public object? this[string key]
        {
            get => _currentScope[key];
            set => _currentScope[key] = value;
        }

        public void Add(string key, object? value, Dictionary<string, object?>? scope = null)
        {
            // allow adding to other scopes to allow callStatements to copy the caller's parameters
            // into the callee's scope for access during function execution.

            if (scope != null)
            {
                scope.Add(key,value);
            }
            else
            {
                _currentScope.Add(key, value);
            }
        }

        public bool TryGetValue(string varName, out object? o) => _currentScope.TryGetValue( varName, out o);

        public void Clear() => _currentScope.Clear();

        public void Push() => _scopedSymbols.Push(new Dictionary<string, object?>());
        public void Push(Dictionary<string, object?> scope) => _scopedSymbols.Push(scope);

        public void Pop() => _scopedSymbols.Pop();

        public void Dump()
        {

            var scope = 0;
            var reversedStack = _scopedSymbols.ToArray().Reverse();
            Console.WriteLine($"Symbols ({_scopedSymbols.Count,2} scopes)");
            Console.WriteLine( "-------------------");
            Console.WriteLine("| Scope  | Symbol                        | Value                                                      |");
//          Console.WriteLine("|--------|-------------------------------|-----------------------------------------------------------|");
            foreach (var table in reversedStack)
            {
                Console.WriteLine("|--------|-------------------------------|------------------------------------------------------------|");
                foreach (var symbol in table)
                {
                    Console.WriteLine($"| {(scope==0 ? "GLOBAL" : scope),6} |{symbol.Key,30} | {symbol.Value,58} |");
                }

                scope++;
            }
        }
    }
}
