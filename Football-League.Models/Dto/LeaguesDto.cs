using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Models.Dto
{
    public class LeaguesDto : BaseModelDto
    {
        public List<LeagueDto> Leagues { get; set; }
        public LeaguesDto()
        {
            Leagues = new List<LeagueDto>();
        }
    }
}
