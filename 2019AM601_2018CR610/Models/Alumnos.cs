using System.ComponentModel.DataAnnotations;

namespace _2019AM601_2018CR610.Models
{
    public class Alumnos
    {
        [Key]
        public int id { get; set; }
        public string carnet { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public int dui { get; set; }
        public int departamentoId { get; set; }
        public int estado { get; set; }
    }
}
