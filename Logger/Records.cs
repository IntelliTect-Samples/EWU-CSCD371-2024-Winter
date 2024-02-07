using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

public abstract record class BaseRecordEntity(string Name): IEntity
{
    public string Name { get; set; } = Name;
    public Guid Id { get; init; } = Guid.NewGuid();
}

public record class BookRecord(string Name, string Author) : BaseRecordEntity(Name)
{
    public string Author { get; init; } = Author;
}

public record class StudentRecord(string Name, string Major) : BaseRecordEntity(Name)
{
    public string Major { get; set; } = Major;
}

public record class EmployeeRecord(string Name, decimal Wage) : BaseRecordEntity(Name)
{
    public decimal Wage { get; set; } = Wage;
}

