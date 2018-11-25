using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Models.Dto
{
    public class MatchStatisticsDto : BaseModelDto
    {
        public List<MatchStatisticDto> Statistics { get; set; }

        public MatchStatisticsDto()
        {
            Statistics = new List<MatchStatisticDto>();
        }
    }
}
