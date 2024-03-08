//using System;
//using Xunit;

//namespace Assignment.Tests;
//public class SampleDataTests
//{
//    [Fact]
//    public void SampleTest()
//    {
//        string str = "meow";
//        Assert.Equal("meow", str);
//    }
//}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {
        private const string TestCsvContent = "Name,Street,City,State,Zip,Email\nJohn Doe,123 Main St,City1,CA,12345,john.doe@email.com\nJane Smith,456 Oak St,City2,NY,67890,jane.smith@email.com";

        [TestMethod]
        public void CsvRows_ReturnsCorrectRows()
        {
            // Arrange
            var mockStreamReader = new Mock<StreamReader>(new MemoryStream(System.Text.Encoding.UTF8.GetBytes(TestCsvContent)));
            var sampleData = new SampleData { StreamReader = mockStreamReader.Object };

            // Act
            var rows = sampleData.CsvRows.ToList();

            // Assert
            CollectionAssert.AreEqual(new[] { "John Doe,123 Main St,City1,CA,12345,john.doe@email.com", "Jane Smith,456 Oak St,City2,NY,67890,jane.smith@email.com" }, rows);
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_ReturnsCorrectList()
        {
            // Arrange
            var sampleData = new SampleData();
            var mockCsvRows = new List<string> { "John Doe,123 Main St,City1,CA,12345,john.doe@email.com", "Jane Smith,456 Oak St,City2,NY,67890,jane.smith@email.com" };
            var mockSampleData = new Mock<SampleData>();
            mockSampleData.Setup(sd => sd.CsvRows).Returns(mockCsvRows);

            // Act
            var result = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

            // Assert
            CollectionAssert.AreEqual(new[] { "CA", "NY" }, result.ToList());
        }

        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRows_ReturnsCorrectString()
        {
            // Arrange
            var sampleData = new SampleData();
            var mockSampleData = new Mock<SampleData>();
            mockSampleData.Setup(sd => sd.GetUniqueSortedListOfStatesGivenCsvRows()).Returns(new[] { "CA", "NY" });

            // Act
            var result = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();

            // Assert
            Assert.AreEqual("CA,NY", result);
        }

        [TestMethod]
        public void People_ReturnsCorrectlyOrderedPeople()
        {
            // Arrange
            var sampleData = new SampleData();
            var mockCsvRows = new List<string> { "Jane Doe,123 Main St,City2,CA,12345,jane.doe@email.com", "John Smith,456 Oak St,City1,NY,67890,john.smith@email.com" };
            var mockSampleData = new Mock<SampleData>();
            mockSampleData.Setup(sd => sd.CsvRows).Returns(mockCsvRows);

            // Act
            var result = sampleData.People.ToList();

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("John ", result[0].FirstName);
            Assert.AreEqual("Doe", result[1].LastName);
        }

        [TestMethod]
        public void FilterByEmailAddress_ReturnsFilteredNames()
        {
            // Arrange
            var sampleData = new SampleData();
            var mockPeople = new List<IPerson>
            {
                new Person("John", "Doe", new Address("123 Main St", "City1", "CA", "12345"), "john.doe@email.com"),
                new Person("Jane", "Smith", new Address("456 Oak St", "City2", "NY", "67890"), "jane.smith@email.com")
            };
            var mockSampleData = new Mock<SampleData>();
            mockSampleData.Setup(sd => sd.People).Returns(mockPeople);

            // Act
            var result = sampleData.FilterByEmailAddress(email => email.Contains("john")).ToList();

            // Assert
            CollectionAssert.AreEqual(new[] { ("John", "Doe") }, result);
        }

        [TestMethod]
        public void GetAggregateListOfStatesGivenPeopleCollection_ReturnsCorrectString()
        {
            // Arrange
            var sampleData = new SampleData();
            var mockPeople = new List<IPerson>
            {
                new Person("John", "Doe", new Address("123 Main St", "City1", "CA", "12345"), "john.doe@email.com"),
                new Person("Jane", "Smith", new Address("456 Oak St", "City2", "NY", "67890"), "jane.smith@email.com")
            };

            // Act
            var result = sampleData.GetAggregateListOfStatesGivenPeopleCollection(mockPeople);

            // Assert
            Assert.AreEqual("CA,NY", result);
        }
    }
}

