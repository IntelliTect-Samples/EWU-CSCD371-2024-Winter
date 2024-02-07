using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

    public record class StudentRecord : PersonName
    {

    public StudentRecord(FullNameRecord FullName) : base(FullName) { }

}

