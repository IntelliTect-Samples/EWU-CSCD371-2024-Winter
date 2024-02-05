using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

public record class BookRecord : BaseEntity
{
    public override string getName()
    {
        throw new NotImplementedException();
    }

    public override void SetName(string name)
    {
        throw new NotImplementedException();
    }
}

