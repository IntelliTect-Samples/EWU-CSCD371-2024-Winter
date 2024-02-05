using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

    public record class StudentRecord : BaseEntity
    {
        

    /*public string Name
    {
        get
        {
           return  null;
        }

        set
        {

            ///FullNameRecord nameRecord = new FullNameRecord(FirstName, MiddleName, LastName);

            //return nameRecord.ToString();
        }
    }*/

    public override string getName()
    {
        throw new NotImplementedException();
    }

    public override void SetName(string name)
    {
        throw new NotImplementedException();
    }
}

