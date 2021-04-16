using Microsoft.AspNetCore.Http;
using MovieDex.Validaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDex.DTOs
{
    public class ActorCreacionDTO: ActorPatchDTO
    {
        
        
        [PesoArchivoValidacion(4)]
        [TipoArchivoValidacion(grupoTipoArchivo: GrupoTipoArchivo.Imagen)]
        public IFormFile Foto { get; set; }
    }
}
