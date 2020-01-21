using AutoMapper;
using Common.DbModels;
using Common.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class GameService
    {
        private readonly GameRepository gameRepository;
        private readonly UserRepository userRepository;
        private readonly IMapper mapper;
        public GameService(GameRepository gameRepository, UserRepository userRepository, IMapper mapper)
        {
            this.gameRepository = gameRepository;
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<GameDTO> Add(string email)
        {
            var user = await userRepository.GetByEmail(email);
            var newGame = new Game()
            {
                UserId = user.Id,
                Ended = false
            };
            var game = await gameRepository.Add(newGame);
            var gameDTO = mapper.Map<GameDTO>(game);
            return gameDTO;
        }
    }
}
