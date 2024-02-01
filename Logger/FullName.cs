using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace Logger
{
    public record FullName(string FirstName, string MiddleName, string LastName)
    {
       // Provide a comment on the full name record on why you selected to define a value or a reference type and ❌✔
       //Provide a comment on the full name record on why or why not the type is immutable.
        public string FirstName { get; } = FirstName ?? throw new ArgumentException(nameof(FirstName));
        public string MiddleName { get; } = MiddleName ?? throw new ArgumentException(nameof(MiddleName));
        public string LastName { get; } = LastName ?? throw new ArgumentException(nameof(LastName));

    }
}
