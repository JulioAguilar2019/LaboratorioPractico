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
    public class DepartamentosController : ControllerBase
    {
        private readonly NotasContext _context;

        public DepartamentosController(NotasContext context)
        {
            this._context = context;
        }

        [HttpGet]
        [Route("api/departamentos")]
        public IActionResult Get()
        {
            IEnumerable<Departamentos> list = from e in _context.departamentos select e;

            if (list.Count() > 0)
            {
                return Ok(list);
            }

            return NotFound();
        }

        [HttpGet]
        [Route("api/departamentos/{id}")]

        public IActionResult Get(int id)
        {
            Departamentos item = (from e in _context.departamentos
                                  where e.id == id
                                   select e).FirstOrDefault();

            if (item != null)
            {
                return Ok(item);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("api/departamentos")]
        public IActionResult guardarEquipo([FromBody] Departamentos item)
        {
            try
            {
                _context.departamentos.Add(item);

                _context.SaveChanges();

                return Ok(item);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("api/departamentos")]
        public IActionResult updateEquipo([FromBody] Departamentos item)
        {
            Departamentos data = (from e in _context.departamentos
                                   where e.id == item.id
                                   select e).FirstOrDefault();

            if (data is null)
            {
                return NotFound();
            }

            data.departamento = item.departamento;

            _context.Entry(data).State = EntityState.Modified;
            _context.SaveChanges();


            return Ok(data);
        }
    }
}
