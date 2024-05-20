using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Globalization;
using System.Net;
using System.Text;
using WebProyectoPrototipoAgricultura.Models.Requests;
using WebProyectoPrototipoAgricultura.Utils;

namespace WebProyectoPrototipoAgricultura.Controllers
{
    public class ProductoController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var nameClaim = User.Identity.Name;
                HttpResponseMessage response = await ApiConnection.Initial().GetAsync($"producto/agricultor/{nameClaim}");
                if (response.IsSuccessStatusCode)
                {
                    var consulta = JsonConvert.DeserializeObject<IEnumerable<Producto>>(response.Content.ReadAsStringAsync().Result);
                    return View(consulta);
                }                                
            }
            return RedirectToAction("Login", "User");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create(IFormCollection collection)
        {
            User agricultor = BuscarAgricultor(User.Identity.Name).Result;
            var json = JsonConvert.SerializeObject(new Producto
            {
                Nombre = collection["Nombre"],
                Descripcion = collection["Descripcion"],
                Precio = Convert.ToInt64(collection["Precio"]),
                CantidadDisponible = Convert.ToInt32(collection["CantidadDisponible"]),
                State = true,
                Agricultor = agricultor,
            });
            var formContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await ApiConnection.InitialWithBearerToken(HttpContext.Request.Cookies[".AspNetCore.Token"]).PostAsync("producto", formContent);
            if (response.StatusCode == HttpStatusCode.Created)
            {
                return RedirectToAction("Index", "Producto");
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return PartialView("~/Views/_UnauthorizedPartial.cshtml");
            }
            return Content("VALIDE LA INFORMACIÓN DEL FORMULARIO");

        }

        private static async Task<User?> BuscarAgricultor(string documentNumber) {
            HttpResponseMessage response = await ApiConnection.Initial().GetAsync($"user/{documentNumber}");
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<User>(result);                
            }
            return null;
        }
    }
}
