using Xunit;

namespace Logger.Tests;

    
    public class FullNameTests
    {
        [Fact]
        public void FullName_NullFirstName_ThrowsArgumentNullException()
        {
        //Arrange
        #pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        Assert.Throws<ArgumentNullException>(() => new FullName(null, "Johnson"));
        #pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }

        [Fact]
        public void FullName_NullLastName_ThrowsArgumentNullException()
        {
        //Arrange
        #pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        Assert.Throws<ArgumentNullException>(() => new FullName("Jake", null));
        #pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }
    }

