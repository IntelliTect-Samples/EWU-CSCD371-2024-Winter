using System;
using Xunit;

namespace Logger.Tests;

public class EmployeeRecordTests
{
    [Fact]
    public void EmployeeRecord_InitializeObjectFullNameParam_Success()
    {
        EmployeeRecord employeeRecord = new(nameof(EmployeeRecord));
        Assert.Equal(nameof(EmployeeRecord), employeeRecord.Name);
    }

    [Fact]
    public void EmployeeRecord_SameEmployee_Success()
    {
        EmployeeRecord employee1 = new(nameof(EmployeeRecord));
        EmployeeRecord employee2 = employee1 with {};
        Assert.True(employee1.Equals(employee2));
    }

    [Fact]
    public void EmployeeRecord_TwoEmployeesNotEqual_Success()
    {
        EmployeeRecord employee1 = new(nameof(EmployeeRecord));
        EmployeeRecord employee2 = new(nameof(EmployeeRecord));
        Assert.False(employee1.Equals(employee2));
    }
}