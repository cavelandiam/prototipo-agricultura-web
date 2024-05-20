using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Security.Claims;
using WebProyectoPrototipoAgricultura.Models;
using WebProyectoPrototipoAgricultura.Models.Requests;
using WebProyectoPrototipoAgricultura.Utils;

namespace WebProyectoPrototipoAgricultura.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }            
            var isFarmerClaim = User.Claims.FirstOrDefault(c => c.Type == "IsFarmer");
            
            if (isFarmerClaim != null)
            {
                if (bool.TryParse(isFarmerClaim.Value, out bool isFarmer) && isFarmer)
                {                    
                    return RedirectToAction("Index", "Producto");
                }
                else
                {                    
                    return RedirectToAction("IndexCliente", "Home");
                }
            }
            return RedirectToAction("Login", "User");
        }

        

        public IActionResult IndexCliente()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Login", "User");
        }
    }
}
