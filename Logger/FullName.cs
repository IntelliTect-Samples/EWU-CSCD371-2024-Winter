using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

public record class FullName(string First, string Last, string? Middle = null)
{
    public void Deconstruct(out string First, out string Last, out string? Middle)
    {
        First = this.First;
        Last = this.Last;
        Middle = this.Middle;
    }
    public override string ToString()
    {
        return $"{First} {((Middle!=null)?Middle + " ":"")}{Last}";
    }
}

