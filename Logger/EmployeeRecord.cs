using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

public record class EmployeeRecord : PersonName, IEntity
{
    //common code for name refactored into PersonName that also inherits from base entity
    //felt reasonable to use FullName for employee, most basic identifier
    public EmployeeRecord(FullNameRecord FullName) : base(FullName) { }

    public override string ToString() => base.ToString();

    //explicitely implemented from IEntity to be accessed through an instance of the interface
    public Guid Id { get; init; }

}
 
