using AutoMapper;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using MovieDex.DTOs;
using MovieDex.Entidades;
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

        public SalasdeCineController(ApplicationDbContext context,
            IMapper mapper)
            : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
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
