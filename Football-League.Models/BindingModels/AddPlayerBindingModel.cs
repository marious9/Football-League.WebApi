using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Football_League.Models.BindingModels
{
    public class AddPlayerBindingModel
    {
        [Required]
        [StringLength(40, ErrorMessage = "Imię powinno zawierać od 3 do 40 znaków", MinimumLength = 2)]
        public string Firstname { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "Nazwisko powinno zawierać od 3 do 40 znaków", MinimumLength = 2)]
        public string Lastname { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
    }
}
