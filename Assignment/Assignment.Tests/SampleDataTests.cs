using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//using Assignment;

namespace Assignment.Tests;
    [TestClass]
    public class SampleDataTests
    {
        [TestMethod]
        public void CsvRows_WhenFileExists_ReturnsEnumerableOfRows()
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

        /*[TestMethod]
        public void CsvRows_WhenFileDoesNotExist_ThrowsFileNotFoundException()
        {
            // Arrange
            var sampleData = new SampleData();

            // Act & Assert
            Assert.ThrowsException<FileNotFoundException>(() => sampleData.CsvRows.ToList());
        }*/

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
    }
