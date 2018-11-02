using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Models.Dto
{
    public class MatchDto : BaseModelDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Round { get; set; }
        public int HostScore { get; set; }
        public int AwayScore { get; set; }
        public TeamDto Host { get; set; }
        public TeamDto Away { get; set; }
        public LeagueDto League { get; set; }
    }
}
