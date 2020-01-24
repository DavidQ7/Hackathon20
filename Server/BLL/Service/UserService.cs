using AutoMapper;
using Common.DbModels;
using Common.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class UserService
    {
        private readonly IMapper mapper;
        private readonly UserRepository userRepository;
        private readonly GameRepository gameRepository;
        public UserService(UserRepository userRepository, IMapper mapper, GameRepository gameRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
            this.gameRepository = gameRepository;
        }

        public async Task<UserDTO> GetByEmail(string email)
        {
            var user = await userRepository.GetByEmail(email);
            var bduser = mapper.Map<UserDTO>(user);
            return bduser;
        }
        public async Task Add(UserDTO user)
        {
            var dbuser = mapper.Map<User>(user);
            await userRepository.Add(dbuser);
        }
        public async Task<Statistic> GetUserStat(string email)
        {
            var user = await userRepository.GetByEmail(email);
            var games = await gameRepository.GetGamesByUserId(user.Id);

            var wins = games.Where(x => x.Won == true).Count();
            var losses = games.Where(x => x.Won == false).Count();
            var notEnded = games.Count() - wins - losses;

            var last_games = games.Skip(Math.Max(0, games.Count() - 20));

            var stat = new Statistic()
            {
                Wins = wins,
                Losses = losses,
                NotFinished = notEnded,
                Games = mapper.Map<List<GameDTO>>(last_games)
            };
            return stat;
        }
    }
}
