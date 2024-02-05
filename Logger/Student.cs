﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public record class Student : Base
    {
        public override string Name { get => GetStudentName(); set => SetStudentName(); }
        private string _firstName;
        private string _lastName;
        private string? _middleName;
        string? full;
        //public override string getName()
        //{
        //    return GetStudentName();
        //}

        //public override void setName(string name)
        //{
        //    throw new NotImplementedException();
        //}
        public Student(string firstName, string lastName, string middleName)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(_firstName);
            ArgumentNullException.ThrowIfNullOrEmpty(_lastName);
            ArgumentNullException.ThrowIfNullOrEmpty(_middleName);
            _firstName = firstName;
            _lastName = lastName;
            _middleName = middleName;
        }
        public Student(string firstName, string lastName)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(_firstName);
            ArgumentNullException.ThrowIfNullOrEmpty(_lastName);
            _firstName = firstName;
            _lastName = lastName;
        }
        private string GetStudentName()
        {
            return full!;

        }
        private void SetStudentName()
        {
            string full;

            if (_middleName != null)
            {
                PersonName personName = new(_firstName, _lastName, _middleName);
                full = personName.makeFullName();
            }
            else
            {
                PersonName personName = new(_firstName, _lastName);
                full = personName.makeFullName();
            }
        }
    }
}
//public override string Name => GetStudentName();