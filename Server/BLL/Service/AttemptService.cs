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
    public class AttemptService
    {
        private readonly AttemptRepository attemptRepository;
        private readonly AuddService auddService;
        private readonly IMapper mapper;
        private readonly GameRepository gameRepository;

        public AttemptService(AttemptRepository attemptRepository, IMapper mapper, AuddService auddService, GameRepository gameRepository)
        {
            this.attemptRepository = attemptRepository;
            this.mapper = mapper;
            this.auddService = auddService;
            this.gameRepository = gameRepository;
        }


        public async Task<AttemptDTO> NewAttempt(NewLyricsAttempt attempt)
        {
            var SoundsList = await auddService.GetByLyrics(attempt.Lyrics);

            if (SoundsList == null)
                return null;

            var Newsound = SoundsList.FirstOrDefault();

            if (Newsound != null)
            {
                var newAttempt = new Attempt()
                {
                    GameId = attempt.GameId,
                    SoundId = Newsound.Song_id
                };
                var dbAttempt = await attemptRepository.Add(newAttempt);

                var _attemptDTO = new AttemptDTO()
                {
                    Id = dbAttempt.Id,
                    LyricsSound = Filter(Newsound)
                };
                return _attemptDTO;
            }
            return null;
        }
        public LyricsSound Filter(LyricsSound last)
        {
            last.Artist = FindBadStr(last.Artist);
            last.Title = FindBadStr(last.Title);
            return last;
        }
        public string FindBadStr(string falseString)
        {
            var str = falseString.Split(' ');
            var strWithoutSep = str.Where(x => !x.Contains(")") && !x.Contains("("));
            return strWithoutSep.Aggregate((x, y) => x + " " + y); 
        }
        public async Task<AttemptDTO> NewAttemptSound(NewAttemptSound attempt)
        {
            var sound = await this.auddService.FindBySoundBase64(attempt);

            if (sound != null)
            {
                var newAttempt = new Attempt()
                {
                    GameId = attempt.GameId,
                    SoundId = 0
                };
                var dbAttempt = await attemptRepository.Add(newAttempt);

                var _attemptDTO = new AttemptDTO()
                {
                    Id = dbAttempt.Id,
                    LyricsSound = sound
                };
                return _attemptDTO;
            }

            return null;
        }
        public async Task<AttemptDTO> NewAttemptVoice(NewAttemptSound attempt)
        {
            var sound = await auddService.FindByVoice(attempt);
            if (sound != null)
            {
                var newAttempt = new Attempt()
                {
                    GameId = attempt.GameId,
                    SoundId = 0
                };
                var dbAttempt = await attemptRepository.Add(newAttempt);

                var _attemptDTO = new AttemptDTO()
                {
                    Id = dbAttempt.Id,
                    LyricsSound = sound
                };
                return _attemptDTO;
            }

            return null;
        }
        public async Task<AttemptDTO> Wrong(WrongAttempt attempt)
        {
            var dbattempt = await attemptRepository.GetById(attempt.Id);
            dbattempt.Result = false;
            await attemptRepository.Update(dbattempt);

            var GameAttempts = await attemptRepository.GetByGameId(attempt.GameId);

            if (GameAttempts.Count > 4 || attempt.Lyrics == "")
            {
                var game = await gameRepository.GetById(attempt.GameId);
                game.Won = true;
                game.Ended = true;
                await gameRepository.Update(game);
                return null;
            }

            var SoundsList = await auddService.GetByLyrics(attempt.Lyrics);
            foreach (var dbGame in GameAttempts)
            {
                var sound = SoundsList.FirstOrDefault(x => x.Song_id == dbGame.SoundId);

                if (sound != null)
                {
                    SoundsList = SoundsList.Where(x => x.Song_id != sound.Song_id).ToList();
                }
            }

            var Newsound = SoundsList.FirstOrDefault();

            if (Newsound != null)
            {
                var newAttempt = new Attempt()
                {
                    GameId = attempt.GameId,
                    SoundId = Newsound.Song_id
                };
                var dbAttempt = await attemptRepository.Add(newAttempt);

                var _attemptDTO = new AttemptDTO()
                {
                    Id = dbAttempt.Id,
                    LyricsSound = Filter(Newsound)
                };
                return _attemptDTO;
            }
            return null;
        }
    }
}
