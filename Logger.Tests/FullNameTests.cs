using Xunit;

namespace Logger.Tests;

//For testing purposes, passing null is allowed so warnging is supressed

public class FullNameTests
    {

    #pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.

        [Fact]
        public void FullName_NullFirstName_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new FullName(null, "Johnson"));
        }

        [Fact]
        public void FullName_NullLastName_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new FullName("Jake", null));
        }

    #pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.


    [Fact]
        public void ToString_NoMiddleName_ReturnsExpectedFormat()
        {
            FullName fullName = new("Jake", "Johnson");

            Assert.Equal("Jake Johnson", fullName.ToString());

        }

        [Fact]
        public void ToString_WithMiddleName_ReturnsExpectedFormat()
        {
            FullName fullName = new("Jake", "Johnson", "Henry");

            Assert.Equal("Jake Henry Johnson", fullName.ToString());

        }


        [Fact]
        public void Equals_SameFirstLastMiddleName_ReturnsTrue()
        {
            FullName fullName1 = new("Jake", "Johnson", "Henry");
            FullName fullName2 = new("Jake", "Johnson", "Henry");

            Assert.Equal(fullName1, fullName2);
            Assert.True(fullName1.Equals(fullName2));
            Assert.True(fullName1 == fullName2);

    }


}

