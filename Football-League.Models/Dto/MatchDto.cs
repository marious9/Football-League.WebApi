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
        public TeamLessDetailsDto Host { get; set; }
        public TeamLessDetailsDto Away { get; set; }
        public LeagueLessDetailsDto League { get; set; }

        public MatchDto()
        {
            Host = new TeamLessDetailsDto();
            Away = new TeamLessDetailsDto();
            League = new LeagueLessDetailsDto();
        }
    }
}
