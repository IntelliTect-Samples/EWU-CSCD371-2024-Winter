using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

//Implimented implicitly since Name isn't causing any collisions, I think?

public record class Book : BaseEntity
{
    public override string Name { get; set; }

    public Book(string title)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(title);
        Name = title;   
    }

}
