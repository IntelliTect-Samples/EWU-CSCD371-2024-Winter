using Xunit;

namespace Logger.Tests
{
    public class FullNameTests
    {
        [Theory]
        [InlineData("First", "Last", "Middle", "First Middle Last")]
        [InlineData("First", "Last", null, "First Last")]
        public void FullName_ToString_HandlesNullMiddle(string first, string last, string? middle, string expects)
        {
            FullName name = new(first, last, middle);
            Assert.Equal(expects, name.ToString());
        }

        [Fact]
        public void FullName_ToString_HandlesOptionalMiddle()
        {
            FullName name = new("First", "Last");
            Assert.Equal("First Last", name.ToString());
        }
    }
}
