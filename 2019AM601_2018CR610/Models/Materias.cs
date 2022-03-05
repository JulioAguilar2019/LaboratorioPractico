using System.ComponentModel.DataAnnotations;

namespace _2019AM601_2018CR610.Models
{
    public class Materias
    {
        [Key]
        public int id { get; set; }
        public int facultadId { get; set; }
        public string materia { get; set; }
        public int unidades_valorativas { get; set; }
        public string estado { get; set; }
    }
}
