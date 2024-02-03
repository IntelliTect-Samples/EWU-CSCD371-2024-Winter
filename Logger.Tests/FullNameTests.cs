using Xunit;

namespace Logger.Tests;

//For testing purposes, passing null is allowed so warnging is supressed
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.

public class FullNameTests
    {
       

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


}

