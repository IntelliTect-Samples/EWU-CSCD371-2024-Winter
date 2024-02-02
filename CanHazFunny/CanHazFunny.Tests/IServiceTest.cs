using Xunit;
using Moq;
using System;
using System.Globalization;
using System.IO;

namespace CanHazFunny.Tests;
#pragma warning disable CA1707


public class IServicetTest
{
    [Fact]
    public void GetJoke_ReturnsJoke()
    {
        // Arrange
        string expectedJoke = "Why don't scientists trust atoms? Because they make up everything.";
        Mock<IService> serviceMock = new();
        serviceMock.Setup(service => service.GetJoke()).Returns(expectedJoke);
        IService service = serviceMock.Object;

        // Act
        string actualJoke = service.GetJoke();

        // Assert
        Assert.Equal(expectedJoke, actualJoke);
    }


}



