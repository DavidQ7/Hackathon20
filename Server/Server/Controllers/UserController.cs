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
    public class UserController : ControllerBase
    {
        private readonly UserService userService;
        public UserController(UserService userService)
        {
            this.userService = userService;
        }


        [HttpGet]
        public async Task<UserDTO> Get()
        {
            var currentUserEmail = this.GetUserEmail();
            var user = await this.userService.GetByEmail(currentUserEmail);
            return user;
        }

        [HttpPost]
        public async Task<UserDTO> Authorize([FromBody]UserDTO user)
        {
            var currentUserEmail = this.GetUserEmail();
            await this.userService.Add(user);
            var dbuser = await userService.GetByEmail(currentUserEmail);
            return dbuser;
        }

        [HttpGet("Statistic")]
        public async Task<Statistic> GetUserStat()
        {
            var currentUserEmail = this.GetUserEmail();
            return await userService.GetUserStat(currentUserEmail);
        }
    }
}