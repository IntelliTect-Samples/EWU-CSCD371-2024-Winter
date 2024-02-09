﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Logger.Tests;

public class BookTests
{
    [Fact]
    public void BookConstructor_CheckingEqualityRecordType_Equal()
    {
        //should return true since they are the same type of records
        Base book1 = new Book("Title");
        Base book2 = new Book("Title");
        Assert.Equal(book1.GetType(), book2.GetType());
    }

    [Fact]
    public void BookConstructor_CheckingEquality_Equal()
    {
        //should return true since they are the same type of records
        Base book1 = new Book("Title");
        Base book2 = new Book("Title");
        Assert.Equal(book1, book2);
    }

    [Fact]
    public void BookConstructor_CheckingEquality_NotEqual()
    {
        //should return true since they are the same type of records
        Base book1 = new Book("Title");
        Base employee = new Employee("FName", "LName", "bill");
        Assert.NotEqual(book1.GetType(), employee.GetType());
    }

    [Fact]
    public void Constructor_CheckingEqualityWithDifferentRecords_NotEqual()
    {
        //should return false since they are different records
        Employee et1 = new("First", "Last", null);
        Book book2 = new("Title");

        Assert.NotEqual(et1.GetType(), book2.GetType());
    }

    [Fact]
    public void Constructor_CheckingEqualityForFullNameVersusObjectType_NotEqualAndEqual()
    {
        //should return false since they are different records
        Book book = new("Title");
        Book book2 = new("Titles");

        Assert.Equal(book.GetType(), book2.GetType());
        Assert.False(book == book2);
    }
}
