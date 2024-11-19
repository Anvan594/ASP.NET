using Microsoft.AspNetCore.Mvc;

namespace Lab8.Areas.admins.Controllers
{
    public class DashboardController : Controller
    {
        [Area("admins")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
