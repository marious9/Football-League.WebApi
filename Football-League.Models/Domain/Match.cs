using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Models.Domain
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Round { get; set; }
        public int HostScore { get; set; }
        public int AwayScore { get; set; }
        public virtual ICollection<MatchPlayer> MatchPlayers { get; set; }
        public virtual Team Host { get; set; }
        public virtual Team Away { get; set; }
    }
}
