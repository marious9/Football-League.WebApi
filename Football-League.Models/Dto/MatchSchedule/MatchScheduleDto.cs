using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Models.Dto.MatchSchedule
{
    public class MatchScheduleDto : BaseModelDto
    {
        public List<MatchQueueDto> Queue { get; set; }

        public MatchScheduleDto()
        {
            Queue = new List<MatchQueueDto>();
        }
    }
}
