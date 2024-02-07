﻿
namespace Logger;

public record class Student(string FirstName, string LastName, int? StudentID) : Person(FirstName, LastName), IEntity
{

    int? StudentID { get; set; } = StudentID ?? throw new ArgumentNullException(nameof(StudentID));

    //Name member of IEntity should explicit becuase it has collision with Employee's name
    string IEntity.Name {get => $"{nameof(Student)} - Name: {Name}, StudentID: {StudentID}"; }
    //Implicit, Id doesn't cause any issues

    public Guid Id { get; init; }

    public override string ToString() => $"Name: {base.ToString()}, StudentID: {StudentID}";


}
