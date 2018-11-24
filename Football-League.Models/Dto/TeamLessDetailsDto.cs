using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Models.Dto
{
    public class TeamLessDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MatchPlayerDto> Players { get; set; }
    }
}
