using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Criptomoedas.Models
{
    public class Criptomoeda
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 3)]
        [Required]
        public string Nome { get; set; } 
        public int Quantidade { get; set; }
        public bool CheckBox { get; set; }
    }
}