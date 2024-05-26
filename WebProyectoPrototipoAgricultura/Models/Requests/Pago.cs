using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using System.ComponentModel;

namespace WebProyectoPrototipoAgricultura.Models.Requests
{
    public class Pago
    {
        [JsonProperty("id")]
        [DisplayName("Id")]
        public long? Id {get; set;}

        [JsonProperty("pedido")]
        [DisplayName("Pedido")]
        public Pedido Pedido {get; set;}

        [JsonProperty("monto")]
        [DisplayName("Monto")]
        public double Monto {get; set;}

        [JsonProperty("metodoPago")]
        [DisplayName("Método de Pago")]
        public string MetodoPago {get; set;}

        [JsonProperty("fechaPago")]
        [DisplayName("Fecha de Pago")]
        public DateTime FechaPago {get; set;}
    }
}
