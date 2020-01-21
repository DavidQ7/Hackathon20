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
    public class GameController : ControllerBase
    {
        private readonly GameService gameService;
        public GameController(GameService gameService)
        {
            this.gameService = gameService;
        }

        [HttpGet("new")]
        public async Task<GameDTO> NewGame()
        {
            var currentUserEmail = this.GetUserEmail();
            return await gameService.Add(currentUserEmail);
        }
    }
}