using Xunit;

namespace Logger.Tests;
public class StorageTests
{
    // Book
    [Fact]
    public void Add_BookRecord_Success()
    {
        BookRecord record = new(nameof(BookRecord));
        

        Storage storage = new();
        storage.Add(record);

        Assert.True(storage.Contains(record));
    }

    [Fact]
    public void Remove_BookRecord_Success()
    {
        BookRecord record = new(nameof(BookRecord));

        Storage storage = new();
        storage.Add(record);

        storage.Remove(record);

        Assert.False(storage.Contains(record));
    }

    [Fact]
    public void Get_ReturnsCorrectBookRecordId_Success()
    {
        BookRecord record = new(nameof(BookRecord));

        Storage storage = new();
        storage.Add(record);

        Assert.Equal<IEntity>(record, storage.Get(record.Id));
    }

    // Student
    [Fact]
    public void Add_StudentRecord_Success()
    {
        StudentRecord studentRecord = new(nameof(StudentRecord));
        Storage storage = new();
        storage.Add(studentRecord);
        Assert.True(storage.Contains(studentRecord));
    }

    [Fact]
    public void Remove_StudentRecord_Success()
    {
        StudentRecord studentRecord = new(nameof(StudentRecord));
        Storage storage = new();
        storage.Add(studentRecord);
        storage.Remove(studentRecord);
        Assert.False(storage.Contains(studentRecord));
    }

    [Fact]
    public void Contains_StudentRecord_Success()
    {
        StudentRecord studentRecord = new(nameof(StudentRecord));
        StudentRecord studentRecord1 = new(nameof(StudentRecord));
        Storage storage = new();
        storage.Add(studentRecord);
        storage.Add(studentRecord1);
        Assert.True(storage.Contains(studentRecord));
    }

    [Fact]
    public void Get_StudentRecord_Success()
    {
        StudentRecord studentRecord = new(nameof(StudentRecord));
        StudentRecord studentRecord1 = new(nameof(StudentRecord));
        Storage storage = new();
        storage.Add(studentRecord);
        storage.Add(studentRecord1);
        Assert.Equal(studentRecord, storage.Get(studentRecord.Id));
    }
    // Employee
    [Fact]
    public void Add_EmployeeRecord_Success()
    {
        EmployeeRecord employeeRecord = new(nameof(EmployeeRecord));
        Storage storage = new();
        storage.Add(employeeRecord);
        Assert.True(storage.Contains(employeeRecord));
    }

    [Fact]
    public void Remove_EmployeeRecord_Success()
    {
        EmployeeRecord employeeRecord = new(nameof(EmployeeRecord));
        Storage storage = new();
        storage.Add(employeeRecord);
        storage.Remove(employeeRecord);
        Assert.False(storage.Contains(employeeRecord));
    }

    [Fact]
    public void Contains_EmployeeRecord_Success()
    {
        EmployeeRecord employeeRecord = new(nameof(EmployeeRecord));
        EmployeeRecord employeeRecord1 = new(nameof(EmployeeRecord));
        Storage storage = new();
        storage.Add(employeeRecord);
        storage.Add(employeeRecord1);
        Assert.True(storage.Contains(employeeRecord));
    }

    [Fact]
    public void Get_EmployeeRecord_Success()
    {
        EmployeeRecord employeeRecord = new(nameof(EmployeeRecord));
        EmployeeRecord employeeRecord1 = new(nameof(EmployeeRecord));
        Storage storage = new();
        storage.Add(employeeRecord);
        storage.Add(employeeRecord1);
        Assert.Equal(employeeRecord, storage.Get(employeeRecord.Id));
    }
}
