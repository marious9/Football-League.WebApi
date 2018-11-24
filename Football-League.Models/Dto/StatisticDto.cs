using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Models.Dto
{
    public class StatisticDto : BaseModelDto
    {
        public int Id { get; set; }
        public int Minute { get; set; }
        public Models.Enums.Action Action { get; set; }
        public MatchPlayerDto MatchPlayer { get; set; }
    }
}
