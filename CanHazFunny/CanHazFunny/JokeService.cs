using System.Net.Http;
namespace CanHazFunny;

    public partial class JokeService : IJokeService
    {
        private HttpClient HttpClient { get; } = new();
        public string GetJoke()
        {
            HttpResponseMessage json = HttpClient.GetAsync("https://geek-jokes.sameerkumar.website/api?format=json").Result;

            string joke = ParseJokeJSON(json.Content.ReadAsStringAsync().Result);

            return joke;
        }

        public static string ParseJokeJSON(string jokeJSON)
        {
            int beginningIndex = jokeJSON.IndexOf(": \"", System.StringComparison.InvariantCulture) + 3;
            int ending = jokeJSON.IndexOf("\"}", System.StringComparison.InvariantCulture);

            return jokeJSON[beginningIndex..ending];
            

        }

}
