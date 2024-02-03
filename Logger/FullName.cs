using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public record class FullName (
        string firstName, string lastName, string middleName);
    //comments needed as well as null and optional
    //could be combined in one file if we want
    //also needs to be setup
}
