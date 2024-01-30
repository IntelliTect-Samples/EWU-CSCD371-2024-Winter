﻿using System.Net.Http;

namespace CanHazFunny;
    public class JokeService : IJokerJokes
    {
        private HttpClient HttpClient { get; } = new();

        public string GetJoke()
        {
            string joke = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api").Result;
            return joke;
        }
    }


