using Microsoft.AspNetCore.Mvc;

namespace Lap9_1.Areas.Admins.Controllers
{
    //[Area("Admins")]
    public class DashboardController :  BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
