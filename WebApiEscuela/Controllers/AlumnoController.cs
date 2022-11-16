using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiEscuela.Data;
using WebApiEscuela.Models;

namespace WebApiEscuela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        public DBEscuelaAPIContext Context { get; set; }
        public AlumnoController(DBEscuelaAPIContext context)
        {
            this.Context = context;
        }

        [HttpGet]
        public List<Alumno> GetAlumnos()
        {
            List<Alumno> todosAlumnos = Context.Alumnos.ToList();
            return todosAlumnos;

        }


        [HttpGet("{id}")]
        public Alumno GetAlumnoID(string id)
        {
            Alumno alumnoID = Context.Alumnos.Find(id);
            return alumnoID;
        }

        [HttpPut("{id}")]
        public ActionResult PutAlumno(string id, [FromBody] Alumno alumno)
        {
            if (id != alumno.Id)
            {
                return BadRequest();
            }
            Context.Entry(alumno).State = EntityState.Modified;
            Context.SaveChanges();
            return NoContent();

        }

        [HttpPost]
        public ActionResult PostAlumno(Alumno alumno)
        {
            //EF --> memoria

            Context.Alumnos.Add(alumno);

            //EF --> DB
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAlumno (string id)
        {
            //primero trato de econtrar al alumno

            Alumno alumno = Context.Alumnos.Find(id);
            if (alumno != null)
            {
                Context.Alumnos.Remove(alumno);
                Context.SaveChanges();
                return Ok();
                
            } else
            {
                return BadRequest();
            }

        }

    }
}
