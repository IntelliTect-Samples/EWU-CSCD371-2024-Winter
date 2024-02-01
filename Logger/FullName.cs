using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public record FullName(string FirstName, string MiddleName, string LastName)
    {
        public string FirstName { get; } = FirstName ?? throw new ArgumentException(nameof(FirstName));
        public string MiddleName { get; } = MiddleName ?? throw new ArgumentException(nameof(MiddleName));
        public string LastName { get; } = LastName ?? throw new ArgumentException(nameof(LastName));

    }
}
