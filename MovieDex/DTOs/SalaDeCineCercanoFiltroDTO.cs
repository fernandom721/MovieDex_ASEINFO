using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDex.DTOs
{
    public class SalaDeCineCercanoFiltroDTO
    {
        [Range(-90, 90)]
        public double Latitud { get; set; }
        [Range(-180, 180)]
        public double Longitud { get; set; }
        public int distanciaEnKm = 10;
        public int distanciaMaxKm = 50;
        public int DistnaciaenKm
        {
            get
            {
                return distanciaEnKm;
            }
            set
            {
                distanciaEnKm = (value > distanciaEnKm) ? distanciaEnKm : value;
            }
        }
    }
}
