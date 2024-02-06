using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;
public abstract class BaseEntity : IEntity
{
    public Guid Id { get; init; } = Guid.NewGuid();
    
    public abstract string Name { get; set; }
}


