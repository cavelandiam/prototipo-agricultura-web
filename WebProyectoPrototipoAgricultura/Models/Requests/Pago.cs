using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using System.ComponentModel;

namespace WebProyectoPrototipoAgricultura.Models.Requests
{
    public class Pago
    {
        [JsonProperty("")]
        [DisplayName("")]
        public long? Id {get; set;}

        [JsonProperty("")]
        [DisplayName("")]
        public Pedido Pedido {get; set;}

        [JsonProperty("")]
        [DisplayName("")]
        public double Monto {get; set;}

        [JsonProperty("")]
        [DisplayName("")]
        public string MetodoPago {get; set;}

        [JsonProperty("")]
        [DisplayName("")]
        public Date FechaPago {get; set;}
    }
}
