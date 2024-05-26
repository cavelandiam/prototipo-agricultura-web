using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace WebProyectoPrototipoAgricultura.Models.Requests
{
    public class Producto
    {
        [JsonProperty("id")]
        [DisplayName("Id")]
        public long Id {get; set;}

        [JsonProperty("nombre")]
        [DisplayName("Nombre")]
        public string Nombre {get; set;}

        [JsonProperty("descripcion")]
        [DisplayName("Descripción")]
        public string Descripcion {get; set;}

        [JsonProperty("precio")]
        [DisplayName("Precio")]
        public double Precio {get; set;}

        [JsonProperty("cantidadDisponible")]
        [DisplayName("Cantidad Disponible")]
        public int CantidadDisponible {get; set;}

        [JsonProperty("agricultor")]
        [DisplayName("Agricultor")]
        public User Agricultor {get; set;}

        [JsonProperty("state")]
        [DisplayName("Estado")]
        public bool State {get; set;}
        
        public bool Selected { get; set; }
    }
}
