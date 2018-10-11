using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Models.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<TeamMatch> TeamMatches { get; set; }
    }
}
