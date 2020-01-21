using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Service;
using Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttemptController : ControllerBase
    {
        private readonly AttemptService attemptService;
        public AttemptController(AttemptService attemptService)
        {
            this.attemptService = attemptService;
        }

        [HttpPost]
        public async Task<AttemptDTO> GetByLyrics(NewLyricsAttempt attempt)
        {
            return await this.attemptService.NewAttempt(attempt);
        }
    }
}