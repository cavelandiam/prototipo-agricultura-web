using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Globalization;
using System.Net;
using System.Security.Claims;
using System.Text;
using WebProyectoPrototipoAgricultura.Models.Requests;
using WebProyectoPrototipoAgricultura.Utils;
using WebProyectoPrototipoAgricultura.ViewModels;

namespace WebProyectoPrototipoAgricultura.Controllers
{
    public class PedidoController : Controller
    {
        private readonly DetallePedidoController _detallePedidoController;
        private readonly PagoController _pagoController;

        public PedidoController(DetallePedidoController detallePedidoController, PagoController pagoController)
        {
            _detallePedidoController = detallePedidoController;
            _pagoController = pagoController;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(new List<Pedido>());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PedidoViewModel model)
        {

            var clientId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var json = JsonConvert.SerializeObject(new Pedido
            {
                Cliente = new User { Id = clientId },
            });
            var formContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await ApiConnection.InitialWithBearerToken(HttpContext.Request.Cookies[".AspNetCore.Token"]).PostAsync("pedido", formContent);

            if (response.StatusCode != HttpStatusCode.Created)
            {
                return BadRequest("No se pudo crear el pedido");
            }

            var pedido = JsonConvert.DeserializeObject<Pedido>(response.Content.ReadAsStringAsync().Result);
            bool detallePedidoResult = await _detallePedidoController.Create(model.Productos, pedido, HttpContext.Request.Cookies[".AspNetCore.Token"]);

            if (!detallePedidoResult)
            {
                return BadRequest("No se agregaron los productos al pedido");
            }

            Pago pagoResult = await _pagoController.Create(pedido, HttpContext.Request.Cookies[".AspNetCore.Token"]);

            if (pagoResult == null)
            {
                return BadRequest("No se pudo registrar el pago del pedido");
            }

            return Ok(pedido);
        }
    }
}
