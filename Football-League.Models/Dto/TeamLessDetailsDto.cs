using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Models.Dto
{
    public class TeamLessDetailsDto : BaseModelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PlayerDtoLessDetails> Players { get; set; }
        public TeamLessDetailsDto()
        {
            Players = new List<PlayerDtoLessDetails>();
        }
    }
}
