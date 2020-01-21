using Common.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class AuddService
    {
        private readonly HttpClient Client;
        private readonly IConfiguration configuration;
        public AuddService(HttpClient Client, IConfiguration configuration)
        {
            Client.BaseAddress = new Uri("https://api.audd.io/");
            this.Client = Client;
            this.configuration = configuration;
        }
        public async Task<string> GetByLyrics(string lyrics)
        {
            var data = new
            {
                method = "findLyrics",
                q = lyrics,
                api_token = configuration["AuddKey"],
            };
            var json  = JsonConvert.SerializeObject(data);
            var response = await Client.PostAsync("", new StringContent(json, Encoding.UTF8, "application/json"));

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var Lyrics = JsonConvert.DeserializeObject<LyricsResponse>(jsonResponse);

            return jsonResponse;
        }
    }
}
