using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Models.Dto
{
    public class PlayerStatisticsDto : BaseModelDto
    {
        public PlayerDtoLessDetails Player { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
        public int MissedPenalties { get; set; }
    }
}
