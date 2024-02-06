using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

public record Student(Guid Id, Name FullName) : IEntity
{
    public string Name => $"{FullName.FirstName} {FullName.MiddleName} {FullName.LastName}";
}

