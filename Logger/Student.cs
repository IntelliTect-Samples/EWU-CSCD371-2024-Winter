﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    internal class Student : Base
    {
        public Student() { }
        public Student(int id) { }

        public override string Name => GetStudentName();

        private string GetStudentName()
        {
            throw new NotImplementedException();
        }
    }
}
