using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class MateriaController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
