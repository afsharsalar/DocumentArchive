using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
