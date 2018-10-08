using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Models.Models
{
    public class Match
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public int Round { get; set; }
        public int HostScore { get; set; }
        public int AwayScore { get; set; }
    }
}
