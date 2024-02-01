using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public record class FullName(string First, string Last, string? Middle = null)
    {
        public override string ToString()
        {
            return $"{First} {((Middle!=null)?Middle + " ":"")}{Last}";
        }
    }
}
