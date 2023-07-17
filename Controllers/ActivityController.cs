using Microsoft.AspNetCore.Mvc;

namespace ActivityTracker.Controllers
{
    public class ActivityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
