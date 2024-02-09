namespace Logger;

public record class StudentRecord(string Name, string Major) : BaseRecordEntity(Name)
{
    public string Major { get; set; } = Major;
}

