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
        public Decimal nota { get; set; }
        public Decimal porcentaje { get; set; }
        public DateTime fecha { get; set; }
    }
}
