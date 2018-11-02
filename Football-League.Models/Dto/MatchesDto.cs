using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Models.Dto
{
    public class MatchesDto : BaseModelDto
    {
        public List<MatchDto> Matches { get; set; }

        public MatchesDto()
        {
            Matches = new List<MatchDto>();
        }
    }
}
