using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Models.Dto.MatchSchedule
{
    public class MatchQueueDto : BaseModelDto
    {
        public int Round { get; set; }
        public List<MatchDto> Matches { get; set; }

        public MatchQueueDto()
        {
            Matches = new List<MatchDto>();
        }
    }
}
