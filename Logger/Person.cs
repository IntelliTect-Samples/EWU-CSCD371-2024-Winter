using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public abstract class Person : BaseEntity
    {
        public Name FullName { get; }

        protected Person(Guid id, Name fullName)
        {
            Id = id;
            FullName = fullName;
        }
    }

    public record Student(Guid Id, Name FullName) : Person(Id, FullName)
    {
        public override string Name => $"{FullName.FirstName} {FullName.MiddleName} {FullName.LastName}";
    }

    public record Employee(Guid Id, Name FullName) : Person(Id, FullName)
    {
        public override string Name => $"{FullName.FirstName} {FullName.MiddleName} {FullName.LastName}";
    }
    }