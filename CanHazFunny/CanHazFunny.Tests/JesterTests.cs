using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace CanHazFunny.Tests;

public class JesterTests
{
    [TestClass]
    public class JesterTests
    {
        [TestMethod]
        public void Constructor_ValidDependencies_InitializesCorrectly()
        {
            // Arrange
            Mock<IJoke> jokeDependencyMock = new Mock<IJoke>();
            Mock<IOutputToScreen> outputDependencyMock = new Mock<IOutputToScreen>();

            // Act
            Jester jester = new Jester(jokeDependencyMock.Object, outputDependencyMock.Object);

            // Assert
            Assert.IsNotNull(jester);
            Assert.AreSame(jokeDependencyMock.Object, jester.GetJokeDependency());
            Assert.AreSame(outputDependencyMock.Object, jester.GetOutputDependency());
        }
    }


    
}
