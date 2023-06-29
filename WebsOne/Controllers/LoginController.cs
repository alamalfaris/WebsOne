using Microsoft.AspNetCore.Mvc;

namespace WebsOne.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
