using Xunit;

namespace Logger.Tests;

public class FullNameRecordTests
{
    [Fact]
        public void FullNameRecord_WithMiddleName_ShouldSetPropertiesCorrectly()
        {
            string firstName = "John";
            string lastName = "Doe";
            string middleName = "Smith";

            var fullNameRecord = new FullNameRecord(firstName, lastName, middleName);

            Assert.Equal(firstName, fullNameRecord.FirstName);
            Assert.Equal(lastName, fullNameRecord.LastName);
            Assert.Equal(middleName, fullNameRecord.MiddleName);
        }


}