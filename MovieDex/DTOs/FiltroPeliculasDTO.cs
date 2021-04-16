using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDex.DTOs
{
    public class FiltroPeliculasDTO
    {
        public int Pagina { get; set; }
        public int CantidadRegistrosPorPagina { get; set; } = 10;
        public PaginacionDTO Paginacion
        {
            get { return new PaginacionDTO() { Pagina = Pagina, 
            CantidadRegistrosXPagina = CantidadRegistrosPorPagina}; }
        }

        public string Titulo { get; set; }
        public int GeneroId { get; set; }
        public bool EnCines { get; set; }
        public bool ProximosEstrenos { get; set; }
    }
}
