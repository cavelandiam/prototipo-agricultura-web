using Microsoft.AspNetCore.Mvc;
using WebProyectoPrototipoAgricultura.Models.Requests;

namespace WebProyectoPrototipoAgricultura.Controllers
{
    public class DetallePedidoController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(new List<DetallePedido>());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return PartialView("~/Views/DetallePedido/Create.cshtml");
        }
    }
}
