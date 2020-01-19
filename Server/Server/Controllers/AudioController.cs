using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AudioController : ControllerBase
    {
        private readonly AudioService audioService;

        public AudioController(AudioService audioService)
        {
            this.audioService = audioService;
        }

        [HttpGet("{lyrics}")]
        public async Task<string> GetByLyrics(string lyrics)
        {
            return await audioService.GetByLyrics(lyrics);
        }
    }
}