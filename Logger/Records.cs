using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

public abstract record class BaseRecordEntity(string name): IEntity
{
    public string Name { get; set; } = name;
    public Guid Id { get; init; } = Guid.NewGuid();
}

public record class BookRecord(string name, string author) : BaseRecordEntity(name)
{
    public string Author { get; init; } = author;
}

public record class StudentRecord(string name, string major) : BaseRecordEntity(name)
{
    public string Major { get; set; } = major;
}

public record class EmployeeRecord(string name, decimal wage) : BaseRecordEntity(name)
{
    public decimal Wage { get; set; } = wage;
}

