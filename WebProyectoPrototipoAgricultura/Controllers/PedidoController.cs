using Microsoft.AspNetCore.Mvc;
using WebProyectoPrototipoAgricultura.Models.Requests;

namespace WebProyectoPrototipoAgricultura.Controllers
{
    public class PedidoController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(new List<Pedido>());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return PartialView("~/Views/Pedido/Create.cshtml");
        }
    }
}
