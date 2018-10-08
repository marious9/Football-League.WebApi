﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Models.Models
{
    public class MatchPlayer
    {
        public long MatchId { get; set; }
        public Match Match { get; set; }
        public long PlayerId { get; set; }
        public Player Player { get; set; }
        public int EntryMinute { get; set; }
        public int DescentMinute { get; set; }
    }
}
