using System;
using Xunit;

namespace CanHazFunny.Tests;

public class IOutJokeTests
{
    //[Fact]
    //public void DisplayJoke_CallMethod_Success()
    //{
      //  MockOutJoke mockClass = new();
        //string joke = mockClass.DisplayJoke(); 
        //Assert.Equal("Why did the chicken cross the road? to get to the othet side", joke);   
    //}
}

public class MockOutJoke : IOutJoke
{
    public void DisplayJoke(string str = "Why did the chicken cross the road? to get to the othet side"){
        Console.WriteLine(str);
    }
}