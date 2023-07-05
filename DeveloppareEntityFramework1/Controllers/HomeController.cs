using Microsoft.AspNetCore.Mvc;

namespace DeveloppareEntityFramework.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
