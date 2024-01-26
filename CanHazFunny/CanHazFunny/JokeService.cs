using System;
using System.Net.Http;

namespace CanHazFunny;

public class JokeService
{
    public class JokeService : IJokeService
    {
        private HttpClient? HttpClient { get; } = new();
        public string GetJoke()
        {
            string joke;
            if (HttpClient == null)
                throw new ArgumentNullException(nameof(HttpClient));
            else
            {
                 joke = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api").Result;
            }
            return joke;
        }
    }
}
