using Microsoft.EntityFrameworkCore;
using WebApiEscuela.Models;

namespace WebApiEscuela.Data
{
    public class DBEscuelaAPIContext : DbContext
    {
        //CORE siempre vamos a declarar el constructor de esta forma
        public DBEscuelaAPIContext(DbContextOptions<DBEscuelaAPIContext> options) : base(options) { }

        //DBST
        public DbSet<Alumno> Alumnos { get; set; }

        public DbSet<Profesor> Profesores { get; set;}

        public DbSet<Especialidad> Especialidades { get; set; }

    }
}
