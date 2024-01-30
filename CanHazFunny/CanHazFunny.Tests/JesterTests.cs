using System;
using System.Diagnostics.Metrics;
using Xunit;

namespace CanHazFunny.Tests;

internal class JokeGetterTest : IJokeGetter
{
    internal string Joke { get; set; } = "";
    internal int Requests { get; set; } = 0;
    public string GetJoke()
    {
        Requests++;
        return Joke;
    }
}

internal class JokeOutputTest : IJokeOutput
{
    public string Joke { get; set; } = "";
    public void TellJoke()
    {
        
    }
}

public class JesterTests
{
    [Fact]
    public void Jester_ThrowsErrorOnNullOutput()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            Jester jester = new(null!, new JokeGetterTest());
        });
    }

    [Fact]
    public void Jester_ThrowsErrorOnNullGetter()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            Jester jester = new(new JokeOutputTest(), null!);
        });
    }

    [Fact]
    public void JesterTellJoke_RejectsChuckNorris()
    {
        JokeGetterTest getter = new()
        {
            Joke = "Blah blah blah Chuck Norris laugh laugh"
        };
        Jester jester = new(new JokeOutputTest(), getter);
        jester.TellJoke();
        Assert.Equal<int>(2, getter.Requests);
    }

    [Fact]
    public void JesterTellJoke_AcceptsNonChuckNorris()
    {
        JokeGetterTest getter = new()
        {
            Joke = "Joke"
        };
        Jester jester = new(new JokeOutputTest(), getter);
        jester.TellJoke();
        Assert.Equal<int>(1, getter.Requests);
    }

    [Fact]
    public void JesterTellsJoke_JokeTellerJokeNotNull()
    {
        JokeGetterTest getter = new()
        {
            Joke = "Joke"
        };
        JokeTeller output = new();
        Jester jester = new(output, getter);
        jester.TellJoke();
        Assert.NotEmpty(output.Joke);
    }
}
