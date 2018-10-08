using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Models.Models
{
    public class Player
    {
        public long Id { get; set; }
        public DateTime BirthDate { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Team Team { get; set; }
    }
}
