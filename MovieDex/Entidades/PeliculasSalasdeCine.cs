using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDex.Entidades
{
    public class PeliculasSalasdeCine
    {
        public int PeliculaId { get; set; }
        public int SaladeCineId { get; set; }
        public Pelicula Pelicula { get; set; }
        public SaladeCine SaladeCine { get; set; }
    }
}
