using System.ComponentModel.DataAnnotations;

namespace _2019AM601_2018CR610.Models
{
    public class Facultad
    {
        [Key]
        public int id { get; set; }
        public string facultad { get; set; }
    }
}
