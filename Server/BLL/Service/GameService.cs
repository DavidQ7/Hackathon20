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
        private readonly AttemptRepository attemptRepository;
        private readonly IMapper mapper;
        public GameService(GameRepository gameRepository, UserRepository userRepository, IMapper mapper, AttemptRepository attemptRepository)
        {
            this.gameRepository = gameRepository;
            this.userRepository = userRepository;
            this.attemptRepository = attemptRepository;
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

        public async Task<GameDTO> EndGame(int id)
        {
            var game = await gameRepository.GetById(id);

            if(game != null)
            {
                game.Ended = true;
            }
            var updateGame = await gameRepository.Update(game);
            var gameDTO = mapper.Map<GameDTO>(updateGame);
            return gameDTO;
        }
        public async Task<GameDTO> EndGameWithWon(int id)
        {
            var game = await gameRepository.GetById(id);

            if (game != null)
            {
                game.Ended = true;
                game.Won = true;
            }
            var updateGame = await gameRepository.Update(game);
            var gameDTO = mapper.Map<GameDTO>(updateGame);
            return gameDTO;
        }
        public async Task<GameDTO> Right(int id)
        {
            var game = await gameRepository.GetByAttemptId(id);
            var attempt = await attemptRepository.GetById(id);

            attempt.Result = true;
            var updateAttempt = await attemptRepository.Update(attempt);

            game.Won = false;
            game.Ended = true;
            var updateGame = await gameRepository.Update(game);

            var returnGame = mapper.Map<GameDTO>(updateGame);
            return returnGame;
        }

    }
}
