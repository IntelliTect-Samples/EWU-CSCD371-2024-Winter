using System.Net.Http;
using System.Text.Json;

namespace CanHazFunny;

public class JokeService: IJokeGetter
{
    private HttpClient HttpClient { get; } = new();

    public string GetJoke()
    {
        string jokeJson = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api?format=json").Result;
        JsonElement jokeElement = JsonDocument.Parse(jokeJson).RootElement;
        return jokeElement.GetProperty("joke").GetString()!;
    }
}
