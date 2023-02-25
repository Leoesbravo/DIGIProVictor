using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Service.Controllers
{
    [Route("api/alumno/")]
    [ApiController]
    public class AlumnoController : Controller
    {
        [EnableCors("CORS")]
        [Route("GetAll")]
        [HttpGet]
        public IActionResult SelectAlumnos()
        {

            Result result = Business.Alumno.GetAlumnos();

            if (result.Correct)
            {
                return Ok(result.Objects);
            }
            else
            {
                return NotFound();
            }
        }

        [EnableCors("CORS")]
        [HttpGet]
        [Route("GetById{IdAlumno}")]
        //GET api/asignatura/5
        public IActionResult SelectAlumno(int IdAlumno)
        {
            Result result = Business.Alumno.GetAlumno(IdAlumno);

            if (result.Correct)
            {
                return Ok(result.Object);
            }
            else
            {
                return NotFound();
            }
        }

        [EnableCors("CORS")]
        [HttpPost]
        [Route("Add")]
        public IActionResult InsertAlumno([FromBody] Alumno alumno)
        {
            Result result = Business.Alumno.InsertAlumno(alumno);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [EnableCors("CORS")]
        [HttpPost]
        [Route("Update")]
        public IActionResult ActualizarAlumno(int IdAlumno, [FromBody] Alumno alumno)
        {

            Result result = Business.Alumno.UpdateAlumno(alumno);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
        [EnableCors("CORS")]
        [HttpGet]
        [Route("Delete{IdAlumno}")]
        //GET api/asignatura/5
        public IActionResult EliminarAlumno(int IdAlumno)
        {
            Alumno alumno = new Alumno();
            alumno.IdAlumno = IdAlumno;

            Result result = Business.Alumno.DeleteAlumno(alumno);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}

