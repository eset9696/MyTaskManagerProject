using Microsoft.AspNetCore.Mvc;

namespace MyTaskManagerProject.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
