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
    public class FacultadController : ControllerBase
    {
        private readonly NotasContext _context;

        public FacultadController(NotasContext context)
        {
            this._context = context;
        }

        [HttpGet]
        [Route("api/facultad")]
        public IActionResult Get()
        {
            IEnumerable<Facultad> list = from e in _context.facultad select e;

            if (list.Count() > 0)
            {
                return Ok(list);
            }

            return NotFound();
        }

        [HttpGet]
        [Route("api/facultad/{id}")]

        public IActionResult Get(int id)
        {
            Facultad item = (from e in _context.facultad
                             where e.id == id
                                  select e).FirstOrDefault();

            if (item != null)
            {
                return Ok(item);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("api/facultad")]
        public IActionResult guardarEquipo([FromBody] Facultad item)
        {
            try
            {
                _context.facultad.Add(item);

                _context.SaveChanges();

                return Ok(item);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("api/facultad")]
        public IActionResult updateEquipo([FromBody] Facultad item)
        {
            Facultad data = (from e in _context.facultad
                             where e.id == item.id
                                  select e).FirstOrDefault();

            if (data is null)
            {
                return NotFound();
            }

            data.facultad = item.facultad;

            _context.Entry(data).State = EntityState.Modified;
            _context.SaveChanges();


            return Ok(data);
        }

    }
}
