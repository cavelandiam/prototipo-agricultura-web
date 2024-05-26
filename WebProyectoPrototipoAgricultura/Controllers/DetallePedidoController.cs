using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using System.Net;
using System.Reflection;
using System.Text;
using WebProyectoPrototipoAgricultura.Models.Requests;
using WebProyectoPrototipoAgricultura.Utils;

namespace WebProyectoPrototipoAgricultura.Controllers
{
    public class DetallePedidoController : Controller
    {       

        [HttpPost]
        public async Task<bool> Create(List<Producto> productos, Pedido pedido, string token)
        {
            List<DetallePedido> detalles = [];
            foreach (var item in productos)
            {
                detalles.Add(new DetallePedido
                {
                    Pedido = pedido,
                    Producto = item,
                    Cantidad = 1,
                    Precio = item.Precio,
                });
            }
            var json = JsonConvert.SerializeObject(detalles);
            var formContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await ApiConnection.InitialWithBearerToken(token).PostAsync("detalle/pedido", formContent);
            return response.StatusCode == HttpStatusCode.Created;
        }
    }
}
