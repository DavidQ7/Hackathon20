using AutoMapper;
using Common.DbModels;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Mappings
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<GameDTO, Game>();
            CreateMap<Game, GameDTO>();
        }
    }
}
