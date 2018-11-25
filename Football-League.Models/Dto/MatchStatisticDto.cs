using Football_League.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Models.Dto
{
    public class MatchStatisticDto
    {
        public int Id { get; set; }
        public int Minute { get; set; }
        public Enums.Action Action { get; set; }
        public MatchPlayerDtoLessDetails MatchPlayer { get; set; }
    }
}
