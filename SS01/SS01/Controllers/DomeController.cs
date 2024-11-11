using Microsoft.AspNetCore.Mvc;

namespace SS01.Controllers
{
    public class DomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
