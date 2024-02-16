using Xunit;

namespace GenericsHomework.Tests;

    public class CircleTests
    {

        [Fact]
        public void Constructor_ValidItem_SetsDataSuccessfully()
        {
            Circle<string> circle = new(["Johanne"]);
            Assert.Contains("Johanne", circle.Elements);

        }
        [Fact]
        public void Add_NullElement_ThrowsNullException()
        {
            Circle<string> circle = new();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => circle.Add(null!));

        }
        [Fact]
        public void Add_MoreCircles_AddsSuccesfully()
        {
            Circle<string> circle = new(["Alexa"]);
            circle.Add("Darrington");
            Assert.Contains("Darrington", circle.Elements);

        }
        [Fact]
        public void ToString_ValidData_PrintsSuccessfully()
        {
            Circle<string> circle = new(["Blue", "Green"]);
            Assert.Equal("Blue, Green", circle.ToString());

        }

    }
