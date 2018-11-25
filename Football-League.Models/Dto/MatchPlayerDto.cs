using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Models.Dto
{
    public class MatchPlayerDto : BaseModelDto
    {
        public int MatchId { get; set; }
        //public MatchDto Match { get; set; }
        public int PlayerId { get; set; }
        public PlayerDto Player { get; set; }
        public int EntryMinute { get; set; }
        public int DescentMinute { get; set; }
        public  ICollection<StatisticDto> Statistics { get; set; }

        public MatchPlayerDto()
        {
            Statistics = new List<StatisticDto>();
        }
    }
}
