using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using _2019AM601_2018CR610.Models;
using Microsoft.EntityFrameworkCore;

namespace _2019AM601_2018CR610.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        private readonly NotasContext _context;

        public MateriaController(NotasContext context)
        {
            this._context = context;
        }

        [HttpGet]
        [Route("api/materia")]
        public IActionResult Get()
        {
            IEnumerable<Materias> list = from e in _context.materias select e;

            if (list.Count() > 0)
            {
                return Ok(list);
            }

            return NotFound();
        }

        [HttpGet]
        [Route("api/materia/{id}")]

        public IActionResult Get(int id)
        {
            Materias item = (from e in _context.materias
                             where e.id == id
                                  select e).FirstOrDefault();

            if (item != null)
            {
                return Ok(item);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("api/materia")]
        public IActionResult guardarEquipo([FromBody] Materias item)
        {
            try
            {
                _context.materias.Add(item);

                _context.SaveChanges();

                return Ok(item);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("api/materia")]
        public IActionResult updateEquipo([FromBody] Materias item)
        {
            Materias data = (from e in _context.materias
                             where e.id == item.id
                                  select e).FirstOrDefault();

            if (data is null)
            {
                return NotFound();
            }

            data.materia = item.materia;

            _context.Entry(data).State = EntityState.Modified;
            _context.SaveChanges();


            return Ok(data);
        }

    }

}
