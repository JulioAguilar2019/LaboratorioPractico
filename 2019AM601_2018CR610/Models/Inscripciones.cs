using System;
using System.ComponentModel.DataAnnotations;

namespace _2019AM601_2018CR610.Models
{
    public class Inscripciones
    {
        [Key]
        public int id { get; set; }
        public int alumnoId { get; set; }
        public int materiaId { get; set; }
        public int inscripcion { get; set; }
        public DateTime fecha { get; set; }
        public string estado { get; set; }
    }
}
