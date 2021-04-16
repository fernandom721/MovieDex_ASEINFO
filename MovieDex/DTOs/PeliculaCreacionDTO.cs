using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieDex.Controllers;
using MovieDex.Helpers;
using MovieDex.Validaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDex.DTOs
{
    public class PeliculaCreacionDTO : PeliculaPatchDTO
    {

        [PesoArchivoValidacion(PesoMaxenMB: 4)]
        [TipoArchivoValidacion(GrupoTipoArchivo.Imagen)]
        public IFormFile Poster { get; set; }

        [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
        public List<int> GenerosIDs { get; set; }

        [ModelBinder(BinderType = typeof(TypeBinder<List<ActorPeliculasCreacionDTO>>))]
        public List<ActorPeliculasCreacionDTO> Actores { get; set; }
    }
}
