using Football_League.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Models.Dto
{
    public class TeamDto : BaseModelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Player> Players { get; set; }
        public ICollection<Match> Matches { get; set; }
        public LeagueDto League { get; set; }

        public TeamDto()
        {
            Players = new List<Player>();
            Matches = new List<Match>();
            League = new LeagueDto();
        }
    }
}
