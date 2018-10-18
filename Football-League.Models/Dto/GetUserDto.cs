using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Models.Dto
{
    public class GetUserDto : BaseModelDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
    }
}
