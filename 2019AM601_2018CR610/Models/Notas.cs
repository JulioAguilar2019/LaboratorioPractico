using System;
using System.ComponentModel.DataAnnotations;

namespace _2019AM601_2018CR610.Models
{
    public class Notas
    {
        [Key]
        public int id { get; set; }
        public int inscripcionId { get; set; }
        public string evaluacion { get; set; }
        public double nota { get; set; }
        public double porcentaje { get; set; }
        public DateTime fecha { get; set; }
    }
}
