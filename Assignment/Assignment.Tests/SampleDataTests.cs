using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assignment;

namespace Assignment.Tests;

    [TestClass]
    public class SampleDataTests
    {


        [TestMethod]
        public void CsvRows_FileExists_ReturnsEnumerableOfRows()
        {
            // Arrange
            var sampleData = new SampleData();
            var expectedRows = new List<string> { "row1", "row2", "row3" };
            CreateCsvFile("People.csv", expectedRows);

            // Act
            var csvRows = sampleData.CsvRows.ToList(); // Materialize to list for easier assertion

            // Assert
            Assert.IsTrue(expectedRows.Skip(1).SequenceEqual(csvRows)); // Skip first row
        }

        // Helper method to create a CSV file with specified rows
        private void CreateCsvFile(string filePath, IEnumerable<string> rows)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var row in rows)
                {
                    writer.WriteLine(row);
                }
            }
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_NoDuplicates_ReturnsSortedStates()
        {
            // Arrange
            var sampleData = new SampleData();

            // Act
            var sortedStates = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

            // Assert
            // Verify uniqueness
            var isUnique = sortedStates.Distinct().Count() == sortedStates.Count();

            // Verify sorting
            var isSorted = sortedStates.Zip(sortedStates.Skip(1), (a, b) => string.Compare(a, b, StringComparison.OrdinalIgnoreCase) <= 0).All(x => x);
            
            // Assert both uniqueness and sorting
            Assert.IsTrue(isUnique, "The list of states contains duplicates.");
            Assert.IsTrue(isSorted, "The list of states is not sorted correctly.");
            // The messages will only display if the IsTrue fails
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_HardCoded_ReturnsSortedStates()
        {
            // Arrange
            var hardcodedAddresses = new List<string>
            {
                "1,John,Doe,john@example.com,123 Main St,Seattle,WA,98101",
                "2,Jane,Smith,jane@example.com,456 Elm St,Bellevue,WA,98004",
            };

            var sampleData = new SampleData();

            // Act
            var result = sampleData.GetUniqueSortedListOfStatesGivenCsvRows(hardcodedAddresses);

            // Assert
            var expectedStates = new List<string> { "WA" }; // Adjust based on your data
            CollectionAssert.AreEqual(expectedStates, result.ToList());
        }


        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRows_ReturnsUniqueCommaSeparatedList()
        {
            // Arrange
            var sampleData = new SampleData();

            // Act
            var result = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();

            // Assert
            // Split the result string into an array using comma as separator
            var statesArray = result.Split(',');

            // Check if each state appears only once
            var isUnique = statesArray.Distinct().Count() == statesArray.Length;

            // Check if the states are sorted
            var isSorted = statesArray.SequenceEqual(statesArray.OrderBy(s => s));

            Assert.IsTrue(isUnique, "The list of states contains duplicates.");
            Assert.IsTrue(isSorted, "The list of states is not sorted correctly.");
        }


        

    }

