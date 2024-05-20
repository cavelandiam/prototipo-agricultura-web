using Microsoft.AspNetCore.Mvc;
using WebProyectoPrototipoAgricultura.Models.Requests;

namespace WebProyectoPrototipoAgricultura.Controllers
{
    public class PagoController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(new List<Pago>());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return PartialView("~/Views/Pago/Create.cshtml");
        }
    }
}
