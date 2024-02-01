using Xunit;
using Moq;
using System;

namespace CanHazFunny.Tests;

public class JesterTests
{
        [Fact]
        public void Constructor_NullJokeService_ThrowsArgumentNullException()
        {
        
            IJokeService jokeService = null;
            IJokeOutput jokeOutput = Mock.Of<IJokeOutput>();

            
            Assert.Throws<ArgumentNullException>(() => new Jester(jokeService, jokeOutput));
        }

        [Fact]
        public void Constructor_NullJokeOutput_ThrowsArgumentNullException()
        {
            
            IJokeService jokeService = Mock.Of<IJokeService>();
            IJokeOutput jokeOutput = null;

            
            Assert.Throws<ArgumentNullException>(() => new Jester(jokeService, jokeOutput));
        }

        
}
