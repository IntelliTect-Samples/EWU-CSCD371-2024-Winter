namespace Logger;
//Implemented implicitly because since it only implements one interface, there was no need to explicitly implement the interface member
public record class StudentRecord(string Name, string Major) : BaseRecordEntity(Name)
{
    public string Major { get; set; } = Major;
}

