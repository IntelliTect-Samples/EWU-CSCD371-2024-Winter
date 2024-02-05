using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;
public abstract class BaseEntity : IEntity
{
    public Guid Id { get; init; }
    
    public string name
    {
        get => GetName();
        set => SetName(value);
    }

    public abstract string GetName();
    //I feel this may need to be protected not 100 percent sure
    protected abstract void SetName(string name);
}


