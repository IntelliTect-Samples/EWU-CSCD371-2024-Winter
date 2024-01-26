using System;
using System.Net.Http;

namespace CanHazFunny;

public class JokeService
{
    public class JokeService : IJokeService
    {
        private HttpClient? HttpClient { get; } = new();

        public JokeService(HttpClient? httpClient)
        {
            HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }


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

        public void SetJoke(string expResult)
        {
            throw new NotImplementedException();
        }
    }
}
