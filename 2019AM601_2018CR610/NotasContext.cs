
using _2019AM601_2018CR610.Models;
using Microsoft.EntityFrameworkCore;

namespace _2019AM601_2018CR610
{
    public class NotasContext : DbContext
    {
        public NotasContext(DbContextOptions<NotasContext> options) : base(options)
        {

        }

        public DbSet<Alumnos> alumnos { get; set; }
        public DbSet<Facultad> facultad { get; set; }
        public DbSet<Materias> materias { get; set; }
        public DbSet<Departamentos> departamentos { get; set; }
        public DbSet<Inscripciones> inscripciones { get; set; }
        public DbSet<Notas> notas { get; set; }
    }
}
