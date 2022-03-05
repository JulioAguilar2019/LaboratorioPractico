﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using _2019AM601_2018CR610.Models;
using Microsoft.EntityFrameworkCore;

namespace _2019AM601_2018CR610.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotasController : ControllerBase
    {
        private readonly NotasContext _context;

        public NotasController(NotasContext context)
        {
            this._context = context;
        }

        [HttpGet]
        [Route("api/notas")]
        public IActionResult Get()
        {
            IEnumerable<Notas> list = from e in _context.notas select e;

            if (list.Count() > 0)
            {
                return Ok(list);
            }

            return NotFound();
        }

        [HttpGet]
        [Route("api/notas/{id}")]

        public IActionResult Get(int id)
        {
            Notas item = (from e in _context.notas
                          where e.id == id
                          select e).FirstOrDefault();

            if (item != null)
            {
                return Ok(item);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("api/notas")]
        public IActionResult guardarEquipo([FromBody] Notas item)
        {
            try
            {
                _context.notas.Add(item);

                _context.SaveChanges();

                return Ok(item);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("api/notas")]
        public IActionResult updateEquipo([FromBody] Notas item)
        {
            Notas data = (from e in _context.notas
                          where e.id == item.id
                          select e).FirstOrDefault();

            if (data is null)
            {
                return NotFound();
            }

            data.nota = item.nota;

            _context.Entry(data).State = EntityState.Modified;
            _context.SaveChanges();


            return Ok(data);
        }
    }
}
