using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Service.Controllers
{
    [Route("api/alumnomateria/")]
    [ApiController]
    public class MateriasAsignadasAlumnoController : Controller
    {
        [EnableCors("CORS")]
        [HttpPost]
        [Route("Add/{idAlumno}/{idMateria}")]
        public IActionResult InsertAlumnoMateria(int idAlumno, int idMateria)
        {
            MateriasAsignadasAlumno alumnoMateria = new MateriasAsignadasAlumno();
            alumnoMateria.Alumno = new Alumno();
            alumnoMateria.Materia = new Materia();

            alumnoMateria.Alumno.IdAlumno = idAlumno;
            alumnoMateria.Materia.IdMateria = idMateria;

            Result result = Business.MateriasAsignadasAlumno.AsignarMaterias(alumnoMateria);

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
        [Route("GetById{IdAlumno}")]
        public IActionResult ObtenerMateriasAsignadasAlumno(int IdAlumno)
        {
            Result result = Business.MateriasAsignadasAlumno.GetMateriasAsignadas(IdAlumno);

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
        [Route("ObtenerMateriasNoAsignadasAlumno{IdAlumno}")]
        public IActionResult ObtenerMateriasNoAsignadasAlumno(int IdAlumno)
        {
            Result result = Business.MateriasAsignadasAlumno.GetMateriasNoAsignadas(IdAlumno);

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
        [Route("Delete{IdAlumno}/{IdMateria}")]
        public IActionResult EliminarAlumnoMateria(int IdMateria, int IdAlumno)
        {

            Result result = Business.MateriasAsignadasAlumno.EliminarMateriaAsignada(IdMateria,IdAlumno);

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

