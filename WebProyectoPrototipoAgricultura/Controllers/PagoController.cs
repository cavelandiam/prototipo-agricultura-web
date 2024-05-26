using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using WebProyectoPrototipoAgricultura.Models.Requests;
using WebProyectoPrototipoAgricultura.Utils;

namespace WebProyectoPrototipoAgricultura.Controllers
{
    public class PagoController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(new List<Pago>());
        }

        [HttpPost]
        public async Task<Pago> Create(Pedido pedido, string token)
        {
            var json = JsonConvert.SerializeObject(new Pago
            {
                Pedido = pedido,
                Monto = 0,
                MetodoPago = "EFECTIVO"
            });
            var formContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await ApiConnection.InitialWithBearerToken(token).PostAsync("pago", formContent);
            if (response.StatusCode != HttpStatusCode.Created)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<Pago>(response.Content.ReadAsStringAsync().Result);
        }
    }
}
