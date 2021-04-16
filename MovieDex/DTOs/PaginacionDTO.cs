using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDex.DTOs
{
    public class PaginacionDTO
    {
        public int Pagina { get; set; } = 1;
        private int cantidadRegistrosXPagina = 10;
        private readonly int cantidadMaxRegistrosXPagina = 50;

        public int CantidadRegistrosXPagina
        {
            get => cantidadRegistrosXPagina;
            set
            {
                cantidadRegistrosXPagina = (value > cantidadMaxRegistrosXPagina) ? cantidadMaxRegistrosXPagina : value;

            }
        }
    }
}
