using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace WebProyectoPrototipoAgricultura.Models.Requests
{
    public class DetallePedido
    {
        [JsonProperty("")]
        [DisplayName("")]
        public long? Id {get; set;}

        [JsonProperty("")]
        [DisplayName("")]
        public Pedido Pedido {get; set;}

        [JsonProperty("")]
        [DisplayName("")]
        public Producto Producto {get; set;}

        [JsonProperty("")]
        [DisplayName("")]
        public int Cantidad {get; set;}

        [JsonProperty("")]
        [DisplayName("")]
        public double Precio {get; set;}
    }
}
