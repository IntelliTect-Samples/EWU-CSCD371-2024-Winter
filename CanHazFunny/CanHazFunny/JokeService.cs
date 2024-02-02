using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace CanHazFunny;

    public partial class JokeService : IJokeService
    {
        private HttpClient HttpClient { get; } = new();
        public string GetJoke()
        {
            HttpResponseMessage json = HttpClient.GetAsync("https://geek-jokes.sameerkumar.website/api").Result;

            string joke = json.Content.ReadAsStringAsync().Result;

            return joke;
        }

        public static string ParseJokeJSON(string jokeJSON)
        {
            int beginningIndex = jokeJSON.IndexOf(": \"") + 3;
            int ending = jokeJSON.IndexOf("\"}}");



            return jokeJSON[beginningIndex..ending];
            

        }

}
