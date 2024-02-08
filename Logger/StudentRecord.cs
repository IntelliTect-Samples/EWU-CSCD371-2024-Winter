using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

    public record class StudentRecord : PersonName
    {
    //common code for name refactored into PersonName that also inherits from base entity
    //felt reasonable to use FullName for a student, most basic identifier
    public StudentRecord(FullNameRecord FullName) : base(FullName) { }

    public override string ToString() => base.ToString();

}

