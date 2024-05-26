using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using System.ComponentModel;

namespace WebProyectoPrototipoAgricultura.Models.Requests
{
    public class Pedido
    {
        [JsonProperty("id")]
        [DisplayName("Id")]
        public long? Id {get; set;}

        [JsonProperty("cliente")]
        [DisplayName("Cliente")]
        public User Cliente {get; set;}

        [JsonProperty("fechaPedido")]
        [DisplayName("Fecha de Pedido")]
        public DateTime FechaPedido {get; set;}

        [JsonProperty("estado")]
        [DisplayName("Estado")]
        public string Estado {get; set;}

        [JsonProperty("detallesPedido")]
        [DisplayName("Detalles del Pedido")]
        public List<DetallePedido> DetallesPedido {get; set;}

        [JsonProperty("total")]
        [DisplayName("Total")]
        public double Total {get; set;}
    }
}
