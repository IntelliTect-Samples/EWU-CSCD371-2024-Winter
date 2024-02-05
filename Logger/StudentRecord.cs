using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

    public record class StudentRecord : BaseEntity
    {

    // FirstName property
    public required string FirstName { get; set; }

    // LastName property
    public required string LastName { get; set; }

    //MiddleName property
    public string? MiddleName
    {
        get => _MiddleName!;
        set => _MiddleName = value;
    }
    private string? _MiddleName;

    // Name property
   
        private string getName()
        {
            FullNameRecord record = new(FirstName, MiddleName!, LastName);
            return record.ToString();
        }
        private void setName(string value)
        {
            // ...
            ArgumentException.ThrowIfNullOrEmpty(value = value?.Trim()!);
            // ...
            // Split the assigned value into 
            // first and last names
            string[] names;
            names = value.Split(new char[] { ' ' });
            if (names.Length == 2)
            {
                FirstName = names[0];
                LastName = names[1];
                MiddleName = null;
            }
            else if (names.Length == 3)
            {
                FirstName = names[0];
                MiddleName = names[1];
                LastName = names[2];
            }
            {
                // Throw an exception if the full 
                // name was not assigned
                throw new System.ArgumentException(
                    $"Assigned value '{value}' is invalid",
                    nameof(value));
            }
        }
    

    public override string Name { get => getName(); set => setName(value); }
}

