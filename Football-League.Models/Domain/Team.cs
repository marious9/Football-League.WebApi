﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Models.Domain
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<Match> HostMatches { get; set; }
        public virtual ICollection<Match> AwayMatches { get; set; }
        public virtual League League { get; set; }
    }
}
