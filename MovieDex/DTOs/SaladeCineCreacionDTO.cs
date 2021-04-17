using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDex.DTOs
{
    public class SaladeCineCreacionDTO
    {
        [Required]
        [StringLength(120)]
        public string Nombre { get; set; }
    }
}
