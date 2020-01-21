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

        public AttemptService(AttemptRepository attemptRepository, IMapper mapper, AuddService auddService)
        {
            this.attemptRepository = attemptRepository;
            this.mapper = mapper;
            this.auddService = auddService;
        }

        public async Task<AttemptDTO> NewAttempt(NewLyricsAttempt attempt)
        {
            var SoundsList = await auddService.GetByLyrics(attempt.Lyrics);
            var GameAttempts = await attemptRepository.GetByGameId(attempt.GameId);

            foreach(var dbGame in GameAttempts)
            {
                var sound = SoundsList.FirstOrDefault(x => x.Song_id == dbGame.Id);

                if(sound != null)
                {
                    SoundsList = SoundsList.Where(x => x.Song_id != sound.Song_id).ToList();
                }
            }

            var Newsound = SoundsList.FirstOrDefault();

            if(Newsound != null)
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
                    LyricsSound = Newsound
                };
                return _attemptDTO;
            }
            return null;
        }
    }
}
