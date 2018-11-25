using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Models.Dto
{
    public class LeagueRankingDto : BaseModelDto
    {
        public List<PlayerStatisticsDto> Players { get; set; }

        public LeagueRankingDto()
        {
            Players = new List<PlayerStatisticsDto>();
        }
    }
}
