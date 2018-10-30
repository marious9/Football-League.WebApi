using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Models.Domain
{
    public class League
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        public virtual User User { get; set; }
    }
}
