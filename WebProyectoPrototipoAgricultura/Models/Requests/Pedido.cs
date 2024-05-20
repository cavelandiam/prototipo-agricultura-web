using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using System.ComponentModel;

namespace WebProyectoPrototipoAgricultura.Models.Requests
{
    public class Pedido
    {
        [JsonProperty("")]
        [DisplayName("")]
        public long? Id {get; set;}

        [JsonProperty("")]
        [DisplayName("")]
        public User Cliente {get; set;}

        [JsonProperty("")]
        [DisplayName("")]
        public Date FechaPedido {get; set;}

        [JsonProperty("")]
        [DisplayName("")]
        public string Estado {get; set;}

        [JsonProperty("")]
        [DisplayName("")]
        public List<DetallePedido> DetallesPedido {get; set;}

        [JsonProperty("")]
        [DisplayName("")]
        public double Total {get; set;}
    }
}
