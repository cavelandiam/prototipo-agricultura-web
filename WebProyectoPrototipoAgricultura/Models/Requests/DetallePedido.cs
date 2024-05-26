using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace WebProyectoPrototipoAgricultura.Models.Requests
{
    public class DetallePedido
    {
        [JsonProperty("id")]
        [DisplayName("Id")]
        public long? Id {get; set;}

        [JsonProperty("pedido")]
        [DisplayName("Pedido")]
        public Pedido Pedido {get; set;}

        [JsonProperty("producto")]
        [DisplayName("Producto")]
        public Producto Producto {get; set;}

        [JsonProperty("cantidad")]
        [DisplayName("Cantidad")]
        public int Cantidad {get; set;}

        [JsonProperty("precio")]
        [DisplayName("Precio")]
        public double Precio {get; set;}
    }
}
