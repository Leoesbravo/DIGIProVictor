using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Service.Controllers
{
    [Route("api/materia/")]
    [ApiController]
    public class MateriaController : Controller
    {
        [EnableCors("CORS")]
        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetMaterias()
        {
            Materia materia = new Materia();

            Result result = Business.Materia.GetMaterias();

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
        [Route("GetById{IdMateria}")]
        public IActionResult GetMateria(int IdMateria)
        {
            Result result = Business.Materia.GetMateria(IdMateria);

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
        public IActionResult InsertMateria([FromBody] Materia materia)
        {
            Result result = Business.Materia.InsertMateria(materia);

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
        public IActionResult ActualizarMateria(int IdMateria, [FromBody] Materia materia)
        {
            Result result = Business.Materia.UpdateMateria(materia);

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
        [Route("Delete{IdMateria}")]
        public IActionResult EliminarMateria(int IdMateria)
        {
            Materia materia = new Materia();
            materia.IdMateria = IdMateria;

            Result result = Business.Materia.DeleteMateria(materia);

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


