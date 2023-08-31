using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace FQL.Parser
{
    public class ErrorManager : IErrorManager
    {
        public ErrorManager() { }

        public List<FQLError> Errors = new List<FQLError>(32);

        public void Add(FQLError error)
        {
            Errors.Add(error);
            if (error.Severity is FQLErrorSeverity.Fatal or FQLErrorSeverity.Error)
            {
                throw new Exception($"HALT: {error.ToString()}");
            }
        }  
        public void Remove(FQLError error) { Errors.Remove(error); }
        public void Clear() { Errors.Clear(); }

        public void Show()
        {
            foreach (var e in Errors)
            {
                Console.WriteLine(e.ToString());
            };
        }

        public bool HasErrors(FQLErrorSeverity showLevel)
        {

            return Errors.Any( e=>e.Severity >= showLevel);
        }
    }
}

