using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

//Implimented implicitly since Name isn't causing any collisions, and if we ever need an Author name we would
// probably add an Author property of Entity type person which would get the Author name through that.

public record class Book : BaseEntity
{
    public override string Name { get; set; }

    public Book(string title)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);
        Name = title;   
    }

}
