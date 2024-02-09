namespace Logger;

public record class EmployeeRecord(string Name, decimal Wage) : BaseRecordEntity(Name)
{
    public decimal Wage { get; set; } = Wage;
}

