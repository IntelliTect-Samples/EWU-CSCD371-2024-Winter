namespace Logger;
//Implemented implicitly because since it only implements one interface, there was no need to explicitly implement the interface member
public record class EmployeeRecord(string Name, decimal Wage) : BaseRecordEntity(Name)
{
    public decimal Wage { get; set; } = Wage;
}

