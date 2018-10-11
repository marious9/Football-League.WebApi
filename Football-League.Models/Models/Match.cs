using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Models.Models
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Round { get; set; }
        public int HostScore { get; set; }
        public int AwayScore { get; set; }
        public virtual ICollection<TeamMatch> TeamMatches { get; set; }
        public virtual ICollection<MatchPlayer> MatchPlayers { get; set; }
    }
}
