using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CanHazFunny;

    public class JokeService : IJokeService
    {
        private HttpClient HttpClient { get; } = new();
        public string GetJoke()
        {
            HttpResponseMessage json = HttpClient.GetAsync("https://geek-jokes.sameerkumar.website/api").Result;

            string joke = json.Content.ReadAsStringAsync().Result;

            return joke;
        }
    }
