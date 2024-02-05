using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

public record Book(Guid Id, string Title) : IEntity
{
    public string Name => Title; //Using a calculated property for name, this way we can avoid fields.
}

