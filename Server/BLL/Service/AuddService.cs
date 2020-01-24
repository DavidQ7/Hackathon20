using Common.Models;
using Common.Models.Audd;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
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
        public async Task<List<LyricsSound>> GetByLyrics(string lyrics)
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

            return Lyrics.Result;
        }
        public async Task<LyricsSound> FindBySoundBase64(NewAttemptSound attempt)
        {
            string base64String = "";
            using (var ms = new MemoryStream())
            {
                await attempt.FormData.CopyToAsync(ms);
                var fileBytes = ms.ToArray();
                base64String = Convert.ToBase64String(fileBytes);
            }

            var data = new
            {
                audio = base64String,
                api_token = configuration["AuddKey"],
                @return = "timecode,deezer"
            };
            var json = JsonConvert.SerializeObject(data);
            var response = await Client.PostAsync("", new StringContent(json, Encoding.UTF8, "application/json"));

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var Lyrics = JsonConvert.DeserializeObject<AudioResponse>(jsonResponse);
            
            return new LyricsSound() {Title = Lyrics.Result.Title, Artist = Lyrics.Result.Artist };
        }
        public async Task FindBySound()
        {

        }
    }
}
