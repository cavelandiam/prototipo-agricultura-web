using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using WebProyectoPrototipoAgricultura.Utils;
using WebProyectoPrototipoAgricultura.Models.Requests;
using System.Text;
using System.ComponentModel;
using System.Net;
using System.Globalization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace WebProyectoPrototipoAgricultura.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View(new List<User>());
            }
            return RedirectToAction("Login", "User");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create(IFormCollection collection)
        {
            var json = JsonConvert.SerializeObject(new User
            {
                DocumentNumber = collection["DocumentNumber"],
                Name = collection["Name"],
                Lastname = collection["Lastname"],
                Username = collection["Username"],
                Email = collection["Email"],
                IsFarmer = Convert.ToBoolean(collection["IsFarmer"].ToString().Split(',')[0]),
                Phone = collection["Phone"],
                Birth = DateTime.Parse(collection["Birth"], new CultureInfo("es-ES")),
            });
            var formContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await ApiConnection.InitialWithBearerToken(HttpContext.Request.Cookies[".AspNetCore.Token"]).PostAsync("user", formContent);
            if (response.StatusCode == HttpStatusCode.Created)
            {
                return RedirectToAction("Login", "User");
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return PartialView("~/Views/_UnauthorizedPartial.cshtml");
            }
            return Content("VALIDE LA INFORMACIÓN DEL FORMULARIO");

        }

        [HttpPost]
        public async Task<IActionResult> Login(IFormCollection collection)
        {            
            var document = collection["userLogin"];
            HttpResponseMessage response = await ApiConnection.Initial().GetAsync($"user/{document}");
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var usuario = JsonConvert.DeserializeObject<User>(result);
                Response.Cookies.Append(".AspNetCore.Token", result, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict });                
                var value = HttpContext.Request.Cookies[".AspNetCore.Token"];
                SetClaimsIdentity(usuario);
                if (usuario.IsFarmer)
                {
                    return RedirectToAction("Index", "Producto");
                }
                return RedirectToAction("IndexCliente", "Home");
            }
            return RedirectToAction("Create", "User");
        }

        private async void SetClaimsIdentity(User usuario)
        {
            ClaimsIdentity claimsIdentity = new(GetClaimsSession(usuario), CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                new AuthenticationProperties
                {
                    IsPersistent = false,
                    //ExpiresUtc = DateTime.UtcNow.AddMinutes(15),
                    RedirectUri = "/User/Login"
                });
        }

        private static List<Claim> GetClaimsSession(User usuario)
        {
            return
                     [
                         new Claim(ClaimTypes.Name, usuario.DocumentNumber),
                         new Claim(ClaimTypes.Role, usuario.IsFarmer.ToString())
                     ];
        }

		public async Task<IActionResult> Logout()
		{
			if (HttpContext.Request.Cookies.Count > 0)
			{
				var siteCookies = HttpContext.Request.Cookies.Where(c => c.Key.Contains(".AspNetCore.") || c.Key.Contains("Microsoft.Authentication") || c.Key.Contains("Cookie"));
				foreach (var cookie in siteCookies)
				{
					Response.Cookies.Delete(cookie.Key);
				}
			}
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Login", "User");
		}
	}
}
