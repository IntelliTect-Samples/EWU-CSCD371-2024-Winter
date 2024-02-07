using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;
public abstract class BaseEntity : IEntity
{
    // Id is implemented implicitly, since BaseEntity only implements one interface
    public Guid Id { get; init; } = Guid.NewGuid();
    // Name is implemented implicitly, since BaseEntity only implements one interface
    public abstract string Name { get; set; }
}


