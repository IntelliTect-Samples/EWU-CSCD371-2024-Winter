using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

// FullName is a reference type because we do not want the data to be immutable, as a person's
// name can change (e.g., when they get married). As a record class, the data is not immutable.
public record class FullName(string First, string? Middle = null, string Last)
{
    public void Deconstruct(out string First, out string? Middle, out string Last)
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

