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
    public class InscripcionesController : ControllerBase
    {
        private readonly NotasContext _context;

        public InscripcionesController(NotasContext context)
        {
            this._context = context;
        }

        [HttpGet]
        [Route("api/inscripciones")]
        public IActionResult Get()
        {
            var list = (from e in _context.inscripciones
                                              join a in _context.alumnos on e.id equals a.id
                                              join m in _context.materias on e.id equals m.id
                                              select new
                                              {
                                                  a.nombre,
                                                  m.materia,
                                                  e.inscripcion,
                                                  e.fecha,
                                                  e.estado
                                              }).ToList();

            if (list.Count() > 0)
            {
                return Ok(list);
            }

            return NotFound();
        }

        [HttpGet]
        [Route("api/inscripciones/{id}")]

        public IActionResult Get(int id)
        {
            var item = (from e in _context.inscripciones
                            where e.id == id
                                  join a in _context.alumnos on e.id equals a.id
                                  join m in _context.materias on e.id equals m.id
                                  select new
                                  {
                                      a.nombre,
                                      m.materia,
                                      e.inscripcion,
                                      e.fecha,
                                      e.estado
                                  }).ToList();

            if (item != null)
            {
                return Ok(item);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("api/inscripciones")]
        public IActionResult guardarEquipo([FromBody] Inscripciones item)
        {
            try
            {
                _context.inscripciones.Add(item);

                _context.SaveChanges();

                return Ok(item);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("api/inscripciones")]
        public IActionResult updateEquipo([FromBody] Inscripciones item)
        {
            Inscripciones data = (from e in _context.inscripciones
                            where e.id == item.id
                            select e).FirstOrDefault();

            if (data is null)
            {
                return NotFound();
            }

            data.alumnoId = item.alumnoId;
            data.materiaId = item.materiaId;
            data.inscripcion = item.inscripcion;
            data.fecha = item.fecha;
            data.estado = item.estado;

            _context.Entry(data).State = EntityState.Modified;
            _context.SaveChanges();


            return Ok(data);
        }
    }
}
