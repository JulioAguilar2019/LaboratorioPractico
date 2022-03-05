using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using _2019AM601_2018CR610.Models;

namespace _2019AM601_2018CR610.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly NotasContext _context;

        public AlumnoController(NotasContext context)
        {
            this._context = context;
        }

        [HttpGet]
        [Route("api/alumnos")]
        public IActionResult Get()
        {
            IEnumerable<Alumnos> list = from e in _context.alumnos select e;

            if (list.Count() > 0)
            {
                return Ok(list);
            }

            return NotFound();
        }

        [HttpGet]
        [Route("api/alumnos/{id}")]

        public IActionResult Get(int id)
        {
            Alumnos item = (from e in _context.alumnos
                                  where e.id == id
                                  select e).FirstOrDefault();

            if (item != null)
            {
                return Ok(item);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("api/alumnos")]
        public IActionResult guardarEquipo([FromBody] Alumnos item)
        {
            try
            {
                _context.alumnos.Add(item);

                _context.SaveChanges();

                return Ok(item);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("api/alumnos")]
        public IActionResult updateEquipo([FromBody] Alumnos item)
        {
            Alumnos data = (from e in _context.alumnos
                                  where e.id == item.id
                                  select e).FirstOrDefault();

            if (data is null)
            {
                return NotFound();
            }

            data.carnet = item.carnet;
            data.nombre = item.nombre;
            data.apellidos = item.apellidos;
            data.dui = item.dui;
            data.departamentoId = item.departamentoId;
            data.estado = item.estado;

            _context.Entry(data).State = EntityState.Modified;
            _context.SaveChanges();


            return Ok(data);
        }
    }
}
