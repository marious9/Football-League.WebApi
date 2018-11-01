using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Models.BindingModels
{
    public class AddPlayerBindingModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
