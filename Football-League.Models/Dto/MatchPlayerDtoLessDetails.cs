using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Models.Dto
{
    public class MatchPlayerDtoLessDetails : BaseModelDto
    {
        public int MatchId { get; set; }
        public int PlayerId { get; set; }
        public PlayerDtoLessDetails Player { get; set; }
        public int EntryMinute { get; set; }
        public int DescentMinute { get; set; }
    }
}
