using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Football_League.Models.BindingModels
{
    public class AddLeagueBindingModel
    {
        [Required]
        [StringLength(40, ErrorMessage = "Nazwa Ligi powinien zawierać od 3 do 40 znaków", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Range(4, 32, ErrorMessage = "Liczba drużyn w lidze powinna mieścić się w zakresie od 4 do 32.")]
        public int Quantity { get; set; }
    }
}
