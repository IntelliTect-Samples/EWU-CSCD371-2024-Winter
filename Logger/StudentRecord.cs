using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

    public record class StudentRecord (FullNameRecord FullName ): BaseEntity( Guid.NewGuid())
    {

    public override string Name => FullName.MiddleName != null
? $"{FullName.FirstName} {FullName.MiddleName} {FullName.LastName}"
: $"{FullName.FirstName} {FullName.LastName}";

}

