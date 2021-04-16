using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MovieDex.Controllers
{
    public class PeliculaPatchDTO
    {

        [Required]
        [StringLength(300)]
        public string Titulo { get; set; }
        public bool EnCines { get; set; }
        public DateTime FechaEstreno { get; set; }
    }
}