using WebProyectoPrototipoAgricultura.Models.Requests;

namespace WebProyectoPrototipoAgricultura.ViewModels
{
    public class PedidoViewModel
    {
        public List<Producto> Productos { get; set; }
        public string Client { get; set; }
    }
}
