﻿using AutoMapper;
using Football_League.Models.Domain;
using Football_League.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Services.Services.Mappers
{
        public static class AutoMapperConfig
        {
        public static IMapper Initialize()
                => new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Team, TeamForGetPlayerDto>();
                    cfg.CreateMap<Player, PlayerDto>();
                    cfg.CreateMap<Team, TeamDto>();
                    cfg.CreateMap<League, LeagueDto>();
                    cfg.CreateMap<User, GetUserDto>();
        }).CreateMapper();
    }
}
