using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

public record class EmployeeRecord( FullNameRecord FullName) : BaseEntity
{

        public override string Name => FullName.MiddleName != null
    ? $"{FullName.FirstName} {FullName.MiddleName} {FullName.LastName}"
    : $"{FullName.FirstName} {FullName.LastName}";


}
 
