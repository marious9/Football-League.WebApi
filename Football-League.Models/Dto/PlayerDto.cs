using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Models.Dto
{
    public class PlayerDto : BaseModelDto
    {
        public int Id { get; set; }
        public DateTime BirthDate { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public TeamForGetPlayerDto Team { get; set; }
    }
}
