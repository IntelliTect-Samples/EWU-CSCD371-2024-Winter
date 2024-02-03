
using System.Globalization;

namespace Logger
{
    public record class FullName(string FirstName, string LastName, string MiddleName = "")
    {
       // Provide a comment on the full name record on why you selected to define a value or a reference type and ❌✔
       //Provide a comment on the full name record on why or why not the type is immutable.
        public string FirstName { get; } = FirstName ?? throw new ArgumentNullException(nameof(FirstName));
        public string MiddleName { get; } = MiddleName;
        public string LastName { get; } = LastName ?? throw new ArgumentNullException(nameof(LastName));

        public override string ToString()
        {

            return $"{FirstName}{(string.IsNullOrWhiteSpace(MiddleName) ? String.Empty : " " +  MiddleName)} {LastName}";
        }

    }
}
