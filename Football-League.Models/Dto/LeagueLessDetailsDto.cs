using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Models.Dto
{
    public class LeagueLessDetailsDto : BaseModelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
