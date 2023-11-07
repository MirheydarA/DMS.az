using Microsoft.AspNetCore.Mvc;

namespace DMS.az.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
