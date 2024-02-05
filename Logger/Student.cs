﻿/*
 * Define book, student, and employee records - all with entity capabilities. ❌✔
Choose a thoughtful approach for the value of Name for each type of entity. In all cases, there should be no backing field for Name (not even one generated by an automatically implemented property) - consider a calculated property. ❌✔
Provide a comment on each interface member in each entity explaining why you implemented it implicitly or explicitly. ❌✔
You should consider the relationship between Student and Employee and refactor the common code shared between them. ❌✔
Given the properties on the full name record, you should consider which entities it makes sense to use it. ❌✔
Test that the equality behavior on these entities behaves as expected. ❌✔
Provide a comment on each interface method explaining why you implemented it implicitly or explicitly.
 */

namespace Logger;

public record Student(Guid Id, FullName StudentName) : EntityBase
{
    // the Name property is implemented explicitly to provide a consistent naming convention.
    public string Name => $"Student: {StudentName.GetFullName}";

}