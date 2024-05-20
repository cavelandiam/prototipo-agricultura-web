using Newtonsoft.Json;
using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebProyectoPrototipoAgricultura.Models.Requests
{
    public class User
    {
        [JsonProperty("id")]
        [DisplayName("Id")]
        public string Id { get; set; }

        [JsonProperty("documentNumber")]
        [DisplayName("Número de Documento")]
        public string DocumentNumber { get; set; }

        [JsonProperty("name")]
        [DisplayName("Nombre")]
        public string Name { get; set; }

        [JsonProperty("lastname")]
        [DisplayName("Apellido")]
        public string Lastname { get; set; }

        [JsonProperty("username")]
        [DisplayName("Nombre de Usuario")]
        public string Username { get; set; }

        [JsonProperty("email")]
        [DisplayName("Correo Electrónico")]
        public string Email { get; set; }

        [JsonProperty("isFarmer")]
        [DisplayName("Es Agricultor")]
        public bool IsFarmer { get; set; }

        [JsonProperty("phone")]
        [DisplayName("Celular")]
        public string Phone { get; set; }

        [JsonProperty("birth")]
        [DisplayName("Fecha de Nacimiento")]
        public DateTime Birth { get; set; }
    }
}
