
namespace Logger
{
    public readonly record struct FullName(string FirstName, string LastName, string MiddleName = "")
    {
        /// <comment>
        /// Fullname is value type. We made this choice becuase it doesn't need to derrive or
        /// inherit from classes. Its also a simple data type of strings.
        /// FullName is immutable. This is becuase we added the readonly modifer to it
        /// </comment>

        public string FirstName { get; } = FirstName ?? throw new ArgumentNullException(nameof(FirstName));
        public string MiddleName { get; } = MiddleName ?? throw new ArgumentNullException(nameof(MiddleName));
        public string LastName { get; } = LastName ?? throw new ArgumentNullException(nameof(LastName));

        public override string ToString()
        {

            return $"{FirstName}{(string.IsNullOrWhiteSpace(MiddleName) ? String.Empty : " " +  MiddleName)} {LastName}";
        }


    }
}
