using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

public record class EmployeeRecord : PersonName
{

    public EmployeeRecord(FullNameRecord FullName) : base(FullName) { }


}
 
