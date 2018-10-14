using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Models.Domain
{
    public class Statistic
    {
        public int Id { get; set; }
        public int Minute { get; set; }
        public Action Action { get; set; }
        public MatchPlayer MatchPlayer { get; set; }
    }
}
