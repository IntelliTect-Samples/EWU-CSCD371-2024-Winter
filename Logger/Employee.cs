﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    internal class Employee : Base
    {
        public Employee() { }

        //public override string Name => getEmployeeName();
        public override string Name { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }

        private string getEmployeeName()
        {
            throw new NotImplementedException();
        }



    }
}
