﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Models.Dto
{
    public class LeagueDto : BaseModelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public List<TeamLessDetailsDto> Teams { get; set; }

        public LeagueDto()
        {
            Teams = new List<TeamLessDetailsDto>();
        }
    }
}
