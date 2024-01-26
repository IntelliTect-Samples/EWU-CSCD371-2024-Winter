﻿using System.Net.Http;
using CanHazFunny.Tests;

namespace CanHazFunny
{
    public class JokeService : IJokeable
    {
        private HttpClient HttpClient { get; } = new();

        public string GetJoke()
        {
            string joke = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api").Result;
            return joke;
        }
    }
}
