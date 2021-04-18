using AutoMapper;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieDex.DTOs;
using MovieDex.Entidades;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDex.Controllers
{
    [Route("api/SalasdeCine")]
    [ApiController]
    public class SalasdeCineController : CustomBaseController
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly GeometryFactory geometryFactory;

        public SalasdeCineController(ApplicationDbContext context,
            IMapper mapper, GeometryFactory geometryFactory)
            : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
            this.geometryFactory = geometryFactory;
        }

        [HttpGet]
        public async Task<ActionResult<List<SaladeCineDTO>>> Get()
        {
            return await Get<SaladeCine, SaladeCineDTO>();
        }

        [HttpGet("{id:int}", Name = "obtenerSalaDeCine")]
        public async Task<ActionResult<SaladeCineDTO>>Get(int id)
        {
            return await Get<SaladeCine, SaladeCineDTO>(id);
        }

        [HttpGet("Cercanos")]
        public async Task<ActionResult<List<SalaDeCineCercanoDTO>>> Cercano(
            [FromQuery] SalaDeCineCercanoFiltroDTO filtro)
        {
            var ubicacionUsuario = geometryFactory.CreatePoint
                (new Coordinate(filtro.Longitud, filtro.Latitud));
            var salasDeCine = await context.SalasdeCines
                .OrderBy(x => x.Ubicacion.Distance(ubicacionUsuario))
                .Where(x => x.Ubicacion.IsWithinDistance(ubicacionUsuario, filtro.DistnaciaenKm * 1000))
                .Select(x => new SalaDeCineCercanoDTO
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Latitud = x.Ubicacion.Y,
                    Longitud = x.Ubicacion.X,
                    DistanciaEnMetros = Math.Round(x.Ubicacion.Distance(ubicacionUsuario))
                }).ToListAsync();

            return salasDeCine;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SaladeCineCreacionDTO saladeCineCreacionDTO)
        {
            return await
                Post<SaladeCineCreacionDTO, SaladeCine, SaladeCineDTO>(saladeCineCreacionDTO,
                "obtenerSalaDeCine");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody]SaladeCineCreacionDTO saladeCineCreacionDTO)
        {
            return await Put<SaladeCineCreacionDTO, SaladeCine>(id, saladeCineCreacionDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            return await Delete<SaladeCine>(id);
        }

    }
}
