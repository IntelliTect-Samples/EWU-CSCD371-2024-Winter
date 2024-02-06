using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    
    public abstract class BaseEntity : IEntity
    {
        //init-only setter for Id (only can be set during initialization)
        public Guid Id { get; init; }
        //Abstract property for Name, ensures derived classes to provide implementation
        public abstract string Name { get; }
    }
}
